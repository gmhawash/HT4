Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class Document
    Inherits MVNetBase

    Public Enum Columns
      CATEGORY
      CATEGORYID
      DESCRIPTION
      NAME
      PASSPROTECT
      SEQ
    End Enum

    Sub New(ByVal hoaUser As HoaUser)
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

    Overloads Function id()
      Return Value("ID")
    End Function

    Function PasswordProtected()
      Return If(Value("PASSPROTECT") = "1", "protected", "")
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

