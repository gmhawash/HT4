Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class Document
    Inherits MVNetBase
    Dim m_hoaUser As HoaUser

    Public Enum Columns
      CATEGORY
      CATEGORYID
      DESCRIPTION
      NAME
      PASSPROTECT
      SEQ
    End Enum

    Sub New(ByVal hoaUser As HoaUser)
      m_hoaUser = hoaUser
      m_TableName = "HOADOCUMENTS"
      m_AccountName = hoaUser.m_AccountName
      ParseColumns([Enum].GetValues(GetType(Columns)))

      m_WriteableColumnList = New List(Of String)(New String() _
        {"CATEGORYID", "DESCRIPTION", "NAME", "PASSPROTECT", "SEQ"})
    End Sub

    Sub New(ByVal item As mvItem)
      m_mvItem = item
      ParseColumns([Enum].GetValues(GetType(Columns)))
    End Sub

    Shared Function FindById(ByVal hoaUser As HoaUser, ByVal Id As String)
      Dim item = New Document(hoaUser)
      item.Read(String.Format("{0}*{1}", hoaUser.id, Id))
      Return item
    End Function

    Function Categories() As List(Of SelectListItem)
      Dim list As List(Of SelectListItem) = New List(Of SelectListItem)
      For Each cat In m_hoaUser.Categories()
        Dim cat_id = cat.Value("CODE")
        list.Add(New SelectListItem With {.Text = cat.Value("DESCRIPTION"), .Value = cat_id, .Selected = (cat_id = Value(Columns.CATEGORYID))})
      Next

      Return list
    End Function

    Overloads Function id()
      Return Value("SEQ")
    End Function

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
  End Class
End Namespace

