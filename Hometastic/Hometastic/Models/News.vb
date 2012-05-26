Imports System
Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class News
    Inherits MVNetBase

#Region "***** Table Definition ***********"
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

    Overrides Function TableColumns()
      m_TableName = "DWNEWS"
      m_WriteableColumnList = New List(Of String)(New String() {"TITLE", "HEADLINE", "BODY", "MGMTCONO"})
      Return [Enum].GetValues(GetType(Columns))
    End Function

    Sub New(ByVal CurrentAccount As MVNetBase)
      MyBase.New(CurrentAccount)
    End Sub

    Sub New(ByVal item As mvItem)
      MyBase.New(item)
    End Sub

    Overloads Shared Function FindById(ByRef CurrentAccount As HoaUser, ByVal Id As String)
      Return MVNetBase.FindById(New News(CurrentAccount), Id)
    End Function

    ' TODO: Can this be moved to base class?
    Overloads Function Id()
      Return m_mvItem.ID.Replace("*", "_")
    End Function

    ' TODO: Can this be moved to base class?
    Overloads Function NextId()
      ' WARNING: This should depend on the type of user (HoaUser vs Management Company)
      Return NextId(String.Format("WITH MGMTCONO = ""{0}""", m_CurrentUser.Id))
    End Function

    Overloads Sub Write(ByVal record As FormCollection)
      If m_mvItem.ID Is Nothing Then record("ID") = m_CurrentUser.Id & "*" & NextId()
      MyBase.Write(record)
    End Sub

#End Region

#Region "******** Model Specific Methods ********"
    Function CreatedDate()
      Return Value(Columns.CREATEDATE)
    End Function

    Function Body() As String
      Dim val = Value(Columns.BODY)
      If val Is Nothing Then Return ""
      Return val.Replace(DataBASIC.VM, DataBASIC.CRLF)
    End Function
#End Region
  End Class
End Namespace

