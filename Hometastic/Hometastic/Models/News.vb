Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class News
    Inherits MVNetBase

    Public Enum Columns
      CREATEDATE
      TITLE
      HEADLINE
      BODY
    End Enum

    Sub New(Optional ByVal accountName As String = "AsiAr")
      m_TableName = "DWNEWS"
      m_AccountName = accountName
      ParseColumns([Enum].GetValues(GetType(Columns)))
      m_WriteableColumnList = New List(Of String)(New String() {"TITLE", "HEADLINE", "BODY"})
    End Sub

    Sub New(ByVal item As mvItem)
      m_mvItem = item
      ParseColumns([Enum].GetValues(GetType(Columns)))
    End Sub

    Function CreatedDate()
      Return Value(Columns.CREATEDATE)
    End Function

    Function Body() As String
      Dim val = Value(Columns.BODY)
      If val Is Nothing Then Return ""
      Return val.Replace(DataBASIC.VM, DataBASIC.CRLF)
    End Function
  End Class
End Namespace

