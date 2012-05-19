Imports System
Imports System.Reflection
Imports BlueFinity.mvNET.CoreObjects

Public Class MVNetBase
  Shared AccountName As String = Nothing
  Shared TableName As String = Nothing
  Shared Account As mvAccount = Nothing

  Protected Friend m_mvAccount As mvAccount
  Protected Friend m_TableName As String = Nothing
  Public m_AccountName As String = "AsiAr"
  Protected Friend m_ColumnNames As String = Nothing
  Protected m_ColumnNamesList As List(Of String) = New List(Of String)
  Protected m_WriteableColumnList As List(Of String)
  Protected Friend m_Dirty As Boolean = True
  Protected Friend m_Valid As Boolean = True
  Protected m_mvItem As mvItem = Nothing
  Protected m_Id As String = Nothing
  Protected m_CurrentUser As MVNetBase = Nothing


  'Shared Function FindById(Of T)(ByVal Id As String)
  '  ' Unfortuantely, Microsoft designs things to be hard to use.  The New() constructor is optional, 
  '  ' so you would think that trying to reflect and find the constructor that has no paramters would
  '  ' find the inherited constructor with the optional parameter, but it does not.  So we try first
  '  ' to find one with no parameters (for shell inherited types - ManagementComapny::Survey) and then
  '  ' try to find ones which take a singel MVNetBase paramater (the CurrentUser optional paramter).
  '  '
  '  ' You also need to invoke them with the exact count of paramters.
  '  '
  '  Try
  '    Dim item As MVNetBase = Nothing
  '    Dim obj As Object = GetType(T).GetConstructor({})

  '    If obj Is Nothing Then
  '      obj = GetType(T).GetConstructor({GetType(MVNetBase)})
  '      If Not obj Is Nothing Then
  '        item = obj.Invoke({New MVNetBase()})
  '      End If
  '    Else
  '      item = obj.Invoke({Nothing})
  '    End If

  '    item.Read(Id)
  '    Return (If(item.Valid, item, Nothing))
  '  Catch ex As Exception
  '    Return Nothing
  '  End Try
  'End Function

  Shared Function Create(Of T)(Optional ByVal CurrentUser As MVNetBase = Nothing)
    Try
      Dim item As MVNetBase = Nothing
      Dim obj As Object = GetType(T).GetConstructor({})

      If obj Is Nothing Then
        obj = GetType(T).GetConstructor({GetType(MVNetBase)})
        If Not obj Is Nothing Then
          item = obj.Invoke({CurrentUser})
        End If
      Else
        item = obj.Invoke({Nothing})
      End If

      item.CreateNewMvItem(CurrentUser)
      Return (If(item.Valid, item, Nothing))
    Catch ex As Exception
      Return Nothing
    End Try
  End Function

  Sub CreateNewMvItem(ByVal CurrentUser As MVNetBase)
    Connect()
    Dim file As mvFile = m_mvAccount.FileOpen(m_TableName)
    m_mvItem = file.NewItem()
    m_CurrentUser = CurrentUser
    Disconnect()
  End Sub

  Function Id()
    Return m_Id
  End Function

  Sub ParseColumns(ByVal ColumnTypes)
    m_ColumnNames = ""

    For Each column In ColumnTypes
      m_ColumnNamesList.Add(column.ToString())
      m_ColumnNames += column.ToString() + " "
    Next

    Dim charsToTrim() As Char = {" "c, ","c}
    m_ColumnNames = m_ColumnNames.Trim(charsToTrim)
  End Sub

  ' TODO: Are these really necessary?
  Overridable Function NewsList()
    Return Nothing
  End Function

  Overridable Function SurveyList()
    Return Nothing
  End Function

  Overridable Function QuestionList()
    Return Nothing
  End Function

  Sub Connect()
    If Not m_AccountName Is Nothing Then
      m_mvAccount = New mvAccount(m_AccountName)
    End If
  End Sub

  Sub Disconnect()
    If Not m_mvAccount Is Nothing Then
      m_mvAccount.Disconnect()
    End If
  End Sub

  Function Value(ByVal key As String) As String
    Try
      Return m_mvItem(key)
    Catch ex As Exception
      Return Nothing
    End Try
  End Function

  Function Value(ByVal key As Integer) As String
    Return Value(m_ColumnNamesList(key))
  End Function

  Function Valid()
    Return m_Valid
  End Function

  Function NextId(Optional ByVal SelectClause As String = Nothing)
    Dim count = 0
    Try
      Connect()
      If SelectClause Is Nothing Then
        count = m_mvAccount.FileCount(m_TableName)
      Else
        count = m_mvAccount.FileCount(m_TableName, SelectClause)
      End If
    Catch ex As Exception
      ' TODO: Handle exceptions
    Finally
      Disconnect()
    End Try
    Return count + 1
  End Function

  '********
  ' Reads a record from the database.
  ' If the record has been read during the request and has not been marked as dirty (by a write)
  ' then just return it.  The record will be read at least once per request.
  '
  Sub Read(ByVal record As String)
    If (Not m_Dirty) Then Return

    m_Id = record

    Try
      Connect()
      Dim file As mvFile = m_mvAccount.FileOpen(m_TableName)
      m_mvItem = file.Read(record, m_ColumnNames)
      ' What happens if this fails?
      m_Dirty = False
    Catch ex As Exception
      ' TODO: Exception Handling
      Throw ex
      m_Valid = False
    Finally
      Disconnect()
    End Try
  End Sub

  Sub Transform(ByRef record As FormCollection)
    For Each item In m_WriteableColumnList
      ' Microsoft has a strange way of handling checkboxes
      ' true,false means it has been checked, false it is not checked.  They do this
      ' to make sure that the "unchecking" of a checkbox is reported by putting
      ' a hidden field with the same name of the checkbox.  That is why we get two 
      ' values for a checked check box (the first comes from the checkbox, the second
      ' from the hidden field.  Actually "false" always comes from the hidden field.
      If record(item) = "true,false" Then record(item) = "1"
      If record(item) = "false" Then record(item) = "0"
      m_mvItem(item) = record(item)
    Next
  End Sub

  '********
  ' Writes a record to the database.
  ' Marks the record as dirty so it can be read again next time.
  '
  Sub Write(Optional ByVal record As FormCollection = Nothing)
    Try
      Connect()
      Dim file As mvFile = m_mvAccount.FileOpen(m_TableName)
      If m_mvItem Is Nothing Then m_mvItem = file.NewItem()
      If Not record Is Nothing Then
        Transform(record)
        If Not record("ID") Is Nothing Then m_mvItem.ID = record("ID")
      End If

      file.Write(m_mvItem)
      ' What happens if this fails?
    Catch ex As Exception
      ' TODO: Exception Handling
      m_Valid = False
    Finally
      m_Dirty = True
      Disconnect()
    End Try
  End Sub

  Sub Delete()
    Try
      Connect()
      Dim file As mvFile = m_mvAccount.FileOpen(m_TableName)
      file.Delete(m_mvItem.ID)
    Catch ex As Exception
    Finally
      m_Valid = False
      m_Dirty = True
      Disconnect()
    End Try


  End Sub

  Function Find(ByVal selectionClause As String, Optional ByVal sortClause As String = Nothing) As mvItemList
    Try
      Connect()
      Dim query = New mvSelect
      Dim file As mvFile = m_mvAccount.FileOpen(m_TableName)

      query.SelectionClause = selectionClause
      query.SortClause = sortClause
      query.DictionaryList = m_ColumnNames
      Return file.Select(query)
    Catch ex As Exception
      ' TODO: Exception Handling
      Throw ex
      Return Nothing
    Finally
      Disconnect()
    End Try
  End Function


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

