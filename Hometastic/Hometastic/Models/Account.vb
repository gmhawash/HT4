Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Globalization
Namespace Models
  Public Class Account
    Public Shared Function Authenticate(ByVal UserName As String, ByVal Password As String, ByVal clientNumber As String, ByVal Type As String) As Boolean

      Return False
    End Function


    Public Shared Function ManagmnetCompany() As Boolean
      Return False
    End Function

    Public Shared Function Hoa() As Boolean
      Return True
    End Function
  End Class
End Namespace