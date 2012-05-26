Imports BlueFinity.mvNET.CoreObjects
Imports System
Namespace Models
  Public Class Category
    Inherits MVNetBase
    Dim m_hoaUser As HoaUser

#Region "***** Table Definition ***********"
    Public Enum Columns
      CODE
      DESCRIPTION
    End Enum

    Overrides Function TableColumns()
      m_TableName = "HOACATEGORIES"
      m_WriteableColumnList = New List(Of String)(New String() {"DESCRIPTION"})
      Return [Enum].GetValues(GetType(Columns))
    End Function

    Sub New(ByRef CurrentAccount As MVNetBase)
      MyBase.New(CurrentAccount)
    End Sub

    Sub New(ByRef item As mvItem)
      MyBase.New(item)
    End Sub

    Overloads Shared Function FindById(ByRef CurrentAccount As HoaUser, ByVal Id As String)
      Return MVNetBase.FindById(New Category(CurrentAccount), CurrentAccount.id & "*" & Id)
    End Function

    'TODO: Can we move this to base class?
    Overloads Function id()
      Return Value("ID")
    End Function

    ' TODO: Can we move this to base class?
    Overloads Function NextId(Optional ByVal SelectClause As String = Nothing)
      Dim Ids = m_hoaUser.Categories().Select(Function(s) Convert.ToInt32(s.Value("CODE")))

      Dim catId = Ids.Min() - 1
      If (catId < 1) Then catId = Ids.Max() + 1

      Return m_hoaUser.id & "*" & catId
    End Function

#End Region
  End Class
End Namespace

