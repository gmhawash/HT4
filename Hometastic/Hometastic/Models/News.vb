Imports System
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

    Sub New(Optional ByVal CurrentUser As MVNetBase = Nothing)
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

