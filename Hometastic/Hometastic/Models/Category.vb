Imports BlueFinity.mvNET.CoreObjects
Imports System
Namespace Models
  Public Class Category
    Inherits MVNetBase
    Dim m_hoaUser As HoaUser

    Public Enum Columns
      CODE
      DESCRIPTION
    End Enum

    Shared Function FindById(ByVal hoaUser As HoaUser, ByVal Id As String)
      Dim item = New Category(hoaUser)
      item.Read(hoaUser.id & "*" & Id)
      Return item
    End Function

    Sub New(Optional ByVal hoaUser As HoaUser = Nothing)
      m_hoaUser = hoaUser
      m_TableName = "HOACATEGORIES"
      If Not hoaUser Is Nothing Then m_AccountName = hoaUser.m_AccountName
      ParseColumns([Enum].GetValues(GetType(Columns)))

      m_WriteableColumnList = New List(Of String)(New String() _
        {"DESCRIPTION"})
    End Sub

    Sub New(ByVal item As mvItem)
      m_mvItem = item
      ParseColumns([Enum].GetValues(GetType(Columns)))
    End Sub

    Overloads Function NextId(Optional ByVal SelectClause As String = Nothing)
      Dim Ids = m_hoaUser.Categories().Select(Function(s) Convert.ToInt32(s.Value("CODE")))

      Dim catId = Ids.Min() - 1
      If (catId < 1) Then catId = Ids.Max() + 1

      Return m_hoaUser.id & "*" & catId
    End Function

    Overloads Function id()
      Return Value("ID")
    End Function
  End Class
End Namespace

