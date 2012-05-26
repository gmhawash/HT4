Imports System
Imports BlueFinity.mvNET.CoreObjects

Namespace Models
  Public Class Provider
    Inherits MVNetBase

#Region "***** Table Definition ***********"
    Public Enum Columns
      DESC
      TITLE
      NAME
      ADDR1
      ADDR2
      CSZ
      CONTACTINFO
      EMAIL
      PHONENO
      CELLNO
      SERVICENO
      VENDNO
      WEBSITEURL
    End Enum

    Overrides Function TableColumns()
      m_TableName = "HOASERVICES"
      m_WriteableColumnList = New List(Of String)(New String() {"DESC", "TITLE", "NAME",
          "ADDR1", "ADDR2", "CSZ", "CONTACTINFO", "EMAIL", "PHONENO", "CELLNO",
          "SERVICENO", "VENDNO", "WEBSITEURL"
           })
      Return [Enum].GetValues(GetType(Columns))
    End Function

    Sub New(ByRef CurrentAccount As MVNetBase)
      MyBase.New(CurrentAccount)
    End Sub

    Sub New(ByRef item As mvItem)
      MyBase.New(item)
    End Sub

    Overloads Shared Function FindById(ByRef CurrentAccount As HoaUser, ByVal Id As String)
      Return MVNetBase.FindById(New Provider(CurrentAccount), Id)
    End Function

    Overloads Function Id()
      Return m_mvItem.ID.Replace("*", "_")
    End Function

    Overloads Function DisplayId()
      Return m_mvItem.ID
    End Function

    Overloads Function NextId()
      Return NextId(String.Format("WITH HOANO = ""{0}""", m_CurrentUser.Id))
    End Function

    Overloads Sub Write(ByVal record As FormCollection)
      If m_mvItem.ID Is Nothing Then record("ID") = m_CurrentUser.Id & "*" & NextId()
      MyBase.Write(record)
    End Sub

#End Region
#Region "***** Model Specific Properties ***********"
    Function Desc() As String
      Dim val = Value(Columns.DESC)
      If val Is Nothing Then Return ""
      Return val.Replace(DataBASIC.VM, DataBASIC.CRLF)
    End Function
#End Region
  End Class
End Namespace

