Imports System
Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class Events
    Inherits MVNetBase

    Public Enum Columns
      EVENTDATE
      EVENTTIME
      NAME
      SHORTDESCRIPTION
      COMPLETEINFO
      URLLINK
      SEQ
    End Enum

    Shared Function FindById(ByVal CurrentAccount, ByVal Id)
      Dim item = New Events(CurrentAccount)
      item.Read(Id)
      Return item
    End Function

    Sub New(Optional ByVal CurrentUser = Nothing)
      m_TableName = "HOAEVENTS"
      If Not CurrentUser Is Nothing Then m_AccountName = CurrentUser.m_AccountName
      m_CurrentUser = CurrentUser
      ParseColumns([Enum].GetValues(GetType(Columns)))
      m_WriteableColumnList = New List(Of String)(New String() {"EVENTDATE", "EVENTTIME", "NAME",
                                                                "SHORTDESCRIPTION", "COMPLETEINFO", "URLLINK"})
    End Sub

    Overloads Function Id()
      Return m_mvItem.ID.Replace("*", "_")
    End Function

    Sub New(ByVal item As mvItem)
      m_mvItem = item
      ParseColumns([Enum].GetValues(GetType(Columns)))
    End Sub

    Overloads Function NextId()
      Return NextId(String.Format("WITH HOANO= ""{0}""", m_CurrentUser.Id))
    End Function

    Overloads Sub Write(ByVal record As FormCollection)
      If m_mvItem.ID Is Nothing Then record("ID") = m_CurrentUser.Id & "*" & NextId()
      MyBase.Write(record)
    End Sub

    Function ShortDescription() As String
      Dim val = Value(Columns.SHORTDESCRIPTION)
      If val Is Nothing Then Return ""
      Return val.Replace(DataBASIC.VM, DataBASIC.CRLF)
    End Function
  End Class
End Namespace

