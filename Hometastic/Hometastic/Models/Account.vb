Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Globalization
Namespace Models
  Public Class Account
    Public Shared Function Authenticate(ByVal UserName As String, ByVal Password As String, ByVal clientNumber As String, ByVal entityType As String) As Boolean
      Dim mgmtCompany = New ManagementCompanyUser
      mgmtCompany.Read(UserName)

      If (entityType = "mgmtCompany") Then
        If (mgmtCompany.Authenticate(UserName, clientNumber, 0, Password)) Then
          HttpContext.Current.Session("CurrentUser") = mgmtCompany
        End If
      ElseIf (entityType = "hoa") Then
        Dim model = New HoaUser
        model.m_TableName = mgmtCompany.Value(ManagementCompanyUser.Columns.MVNETLOGIN)
        If (model.Authenticate(UserName, clientNumber, 1, Password)) Then
          HttpContext.Current.Session("CurrentUser") = model
        End If
      End If
      Return False
    End Function

    Public Shared Function IsManagmnetCompanyUser() As Boolean
      Dim model As MVNetBase = HttpContext.Current.Session("CurrentUser")
      Return model.GetType() = GetType(ManagementCompanyUser)
    End Function

    Public Shared Function IsHoaUser() As Boolean
      Dim model As MVNetBase = HttpContext.Current.Session("CurrentUser")
      Return model.GetType() = GetType(HoaUser)
    End Function
  End Class
End Namespace