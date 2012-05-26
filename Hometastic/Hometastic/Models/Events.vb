Imports System
Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class Events
    Inherits MVNetBase

#Region "***** Table Definition ***********"
    Public Enum Columns
      EVENTDATE
      EVENTTIME
      NAME
      SHORTDESCRIPTION
      COMPLETEINFO
      URLLINK
      SEQ
    End Enum

    Overrides Function TableColumns()
      m_TableName = "HOAEVENTS"
      m_WriteableColumnList = New List(Of String)(New String() {"EVENTDATE", "EVENTTIME", "NAME",
                                                                "SHORTDESCRIPTION", "COMPLETEINFO", "URLLINK"})
      Return [Enum].GetValues(GetType(Columns))
    End Function

    Sub New(ByRef CurrentAccount As MVNetBase)
      MyBase.New(CurrentAccount)
    End Sub

    Sub New(ByRef item As mvItem)
      MyBase.New(item)
    End Sub

    Overloads Shared Function FindById(ByRef CurrentAccount As HoaUser, ByVal Id As String)
      Return MVNetBase.FindById(New Events(CurrentAccount), Id)
    End Function

    Overloads Function Id()
      Return m_mvItem.ID.Replace("*", "_")
    End Function

    Overloads Function NextId()
      Return NextId(String.Format("WITH HOANO= ""{0}""", m_CurrentUser.Id))
    End Function

    Overloads Sub Write(ByVal record As FormCollection)
      If m_mvItem.ID Is Nothing Then record("ID") = m_CurrentUser.Id & "*" & NextId()
      MyBase.Write(record)
    End Sub
#End Region

#Region "***** Model Specific Functions ***********"
    Function ShortDescription() As String
      Dim val = Value(Columns.SHORTDESCRIPTION)
      If val Is Nothing Then Return ""
      Return val.Replace(DataBASIC.VM, DataBASIC.CRLF)
    End Function
#End Region
  End Class
End Namespace

