Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class News
    Inherits MVNetBase

    Public Enum Columns
      CREATEDATE
      TITLE
      HEADLINE
      BODY
      HNAME
      HOANAME
      HOANO
      MNAME
      MGMTCONAME
      MGMTCONO
      SEQ
    End Enum

    Sub New(Optional ByRef CurrentUser As MVNetBase = Nothing)
      m_TableName = "DWNEWS"
      If Not CurrentUser Is Nothing Then m_AccountName = CurrentUser.m_AccountName
      m_CurrentUser = CurrentUser
      ParseColumns([Enum].GetValues(GetType(Columns)))
      m_WriteableColumnList = New List(Of String)(New String() {"TITLE", "HEADLINE", "BODY", "MGMTCONO"})
    End Sub

    Overloads Function Id()
      Return m_mvItem.ID.Replace("*", "_")
    End Function

    Sub New(ByVal item As mvItem)
      m_mvItem = item
      ParseColumns([Enum].GetValues(GetType(Columns)))
    End Sub

    Overloads Function NextId()
      Return NextId(String.Format("WITH MGMTCONO = ""{0}""", m_CurrentUser.Id))
    End Function

    Overloads Sub Write(ByVal record As FormCollection)
      If m_mvItem.ID Is Nothing Then record("ID") = m_CurrentUser.Id & "*" & NextId()
      MyBase.Write(record)
    End Sub

    Public Function FindById(ByVal thisId As String) As News
      Dim itemList = MyBase.Find(String.Format("WITH ID=""{0}""", thisId))
      Dim itemCount = itemList.Count

      If itemCount = 1 Then
        Return New News(itemList(0))
      ElseIf itemCount > 1 Then
        Throw New Exception("More than one item exists with the same ID")
      End If

      Return Nothing
    End Function

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

