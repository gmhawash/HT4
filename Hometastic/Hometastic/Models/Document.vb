Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class Document
    Inherits MVNetBase
    Dim m_hoaUser As HoaUser

#Region "***** Table Definition ***********"
    Public Enum Columns
      CATEGORY
      CATEGORYID
      DESCRIPTION
      NAME
      PASSPROTECT
      SEQ
    End Enum

    Overrides Function TableColumns()
      m_TableName = "HOADOCUMENTS"
      m_WriteableColumnList = New List(Of String)(New String() _
        {"CATEGORYID", "DESCRIPTION", "NAME", "PASSPROTECT", "SEQ"})
      Return [Enum].GetValues(GetType(Columns))
    End Function

    Sub New(ByRef CurrentAccount As MVNetBase)
      MyBase.New(CurrentAccount)
    End Sub

    Sub New(ByRef item As mvItem)
      MyBase.New(item)
    End Sub

    Overloads Shared Function FindById(ByRef CurrentAccount As HoaUser, ByVal Id As String)
      Return MVNetBase.FindById(New Document(CurrentAccount), String.Format("{0}*{1}", CurrentAccount.id, Id))
    End Function

    Overloads Function id()
      Return Value("SEQ")
    End Function

#End Region


#Region "***** Association Lists ***********"
    Function Categories() As List(Of SelectListItem)
      Dim list As List(Of SelectListItem) = New List(Of SelectListItem)
      For Each cat In m_hoaUser.Categories()
        Dim cat_id = cat.Value("CODE")
        list.Add(New SelectListItem With {.Text = cat.Value("DESCRIPTION"), .Value = cat_id, .Selected = (cat_id = Value(Columns.CATEGORYID))})
      Next

      Return list
    End Function

#End Region

#Region "***** Model Specific Properties ***********"
    Function AuthorizationLevels() As List(Of SelectListItem)
      Dim list As List(Of SelectListItem) = New List(Of SelectListItem)
      Dim level = Value(Columns.PASSPROTECT)
      list.Add(New SelectListItem With {.Value = "0", .Text = "None", .Selected = (level = "0")})
      list.Add(New SelectListItem With {.Value = "1", .Text = "Activate", .Selected = (level = "1")})
      Return list
    End Function

    Function AuthorizationLevel() As String
      Return ("authorization_level_" & Value(Columns.PASSPROTECT))
    End Function

    Public Property Category() As String
      Get
        Return Value("CATEGORYID")
      End Get
      Set(ByVal value As String)
      End Set
    End Property
#End Region

  End Class
End Namespace

