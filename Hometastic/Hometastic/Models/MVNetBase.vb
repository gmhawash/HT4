Imports BlueFinity.mvNET.CoreObjects

Namespace Models

  Public Class MVNetBase
    Protected Friend m_mvAccount As mvAccount
    Protected Friend m_TableName As String = vbNull
    Protected Friend m_AccountName As String = "AsiAr"
    Protected Friend m_ColumnNames As String = vbNull
    Protected Friend m_Dirty As Boolean = True
    Protected m_mvItem As mvItem = New mvItem()

    Sub ParseColumns(ByVal ColumnTypes)
      m_ColumnNames = ""

      For Each column In ColumnTypes
        m_ColumnNames += column.ToString() + " "
      Next

      Dim charsToTrim() As Char = {" "c, ","c}
      m_ColumnNames = m_ColumnNames.Trim(charsToTrim)
    End Sub

    Sub Connect()
      m_mvAccount = New mvAccount(m_AccountName)
    End Sub

    Sub Disconnect()
      m_mvAccount.Disconnect()
    End Sub


    Function Read(ByVal record As String) As mvItem
      If (Not m_Dirty) Then Return m_mvItem

      Connect()
      Dim file As mvFile = m_mvAccount.FileOpen(m_TableName)
      m_mvItem = file.Read(record, m_ColumnNames)
      Disconnect()
      Return m_mvItem
    End Function
  End Class
End Namespace
