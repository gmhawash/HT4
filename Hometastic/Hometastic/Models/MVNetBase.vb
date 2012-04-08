﻿Imports BlueFinity.mvNET.CoreObjects

Namespace Models

  Public Class MVNetBase
    Protected Friend m_mvAccount As mvAccount
    Protected Friend m_TableName As String = vbNull
    Protected Friend m_AccountName As String = "AsiAr"
    Protected Friend m_ColumnNames As String = vbNull
    Protected m_ColumnNamesList As List(Of String) = New List(Of String)
    Protected Friend m_Dirty As Boolean = True
    Protected Friend m_Valid As Boolean = True
    Protected m_mvItem As mvItem = New mvItem()

    Sub ParseColumns(ByVal ColumnTypes)
      m_ColumnNames = ""

      For Each column In ColumnTypes
        m_ColumnNamesList.Add(column.ToString())
        m_ColumnNames += column.ToString() + " "
      Next

      Dim charsToTrim() As Char = {" "c, ","c}
      m_ColumnNames = m_ColumnNames.Trim(charsToTrim)
    End Sub

    Sub Connect()
      If m_AccountName Then
        m_mvAccount = New mvAccount(m_AccountName)
      End If
    End Sub

    Sub Disconnect()
      If Not m_mvAccount Is Nothing Then
        m_mvAccount.Disconnect()
      End If
    End Sub

    Function Value(ByVal key As Integer) As String
      Try
        Return m_mvItem(m_ColumnNamesList(key))
      Catch ex As Exception
        Return Nothing
      End Try
    End Function

    Function Valid()
      Return m_Valid
    End Function

    '********
    ' Reads a record from the database.
    ' If the record has been read during the request and has not been marked as dirty (by a write)
    ' then just return it.  The record will be read at least once per request.
    '
    Sub Read(ByVal record As String)
      If (Not m_Dirty) Then Return

      Try
        Connect()
        Dim file As mvFile = m_mvAccount.FileOpen(m_TableName)
        m_mvItem = file.Read(record, m_ColumnNames)
        ' What happens if this fails?
        m_Dirty = False
      Catch ex As Exception
        ' TODO: Exception Handling
        m_Valid = False
      Finally
        Disconnect()
      End Try
    End Sub

    '******
    ' Calls the MV.NET database requesting authentication of mgmtCompany or Hoa User.
    ' A mgmtCompany and a password are needed to authenticate a management company
    ' A clientNumber and a password are needed to authenticate an HOA 
    '
    ' Returns: True for successful authetication, False otherwise
    '
    Function Authenticate(ByVal managmentCompany As String, ByVal clientNumber As String, ByVal entityType As Integer, ByVal password As String) As Boolean
      Try
        Connect()
        Dim argsArray As String = managmentCompany + DataBASIC.AM + clientNumber + DataBASIC.AM + entityType.ToString + DataBASIC.AM + password
        m_mvAccount.CallProg("DWHTADMIN.VALIDATE", argsArray)
        Dim retCode = argsArray.Split(DataBASIC.AM)(0)
        Return (retCode = "1")
      Catch ex As Exception
        ' TODO: Exception Handling
        Return False
      Finally
        Disconnect()
      End Try
    End Function
  End Class

End Namespace
