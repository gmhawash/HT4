Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class Category
    Inherits MVNetBase

    Public Enum Columns
      DESCRIPTION
    End Enum

    Sub New(ByVal hoaUser As HoaUser)
      m_TableName = "HOACATEGORIES"
      m_AccountName = hoaUser.m_AccountName
      ParseColumns([Enum].GetValues(GetType(Columns)))

      m_WriteableColumnList = New List(Of String)(New String() _
        {"DESCRIPTION"})
    End Sub

    Sub New(ByVal item As mvItem)
      m_mvItem = item
      ParseColumns([Enum].GetValues(GetType(Columns)))
    End Sub

    Overloads Function id()
      Return Value("ID")
    End Function
  End Class
End Namespace

