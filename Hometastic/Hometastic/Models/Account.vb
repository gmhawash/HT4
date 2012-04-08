Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Globalization
Imports MvcFlash.Core

Namespace Models
  Public Class Account
    ' Try to authenticate the user (either a management company or HOA)
    ' If sucessful, save the appropriate model into the session for future reference.
    '
    Public Shared Function Authenticate(ByVal UserName As String, ByVal Password As String, ByVal clientNumber As String, ByVal entityType As String) As Boolean
      Dim mgmtCompany = New ManagementCompanyUser
      mgmtCompany.Read(UserName)
      LogOut()

      If (entityType = "ManagementCompany") Then
        If (mgmtCompany.Authenticate(UserName, clientNumber, 0, Password)) Then
          HttpContext.Current.Session("CurrentUser") = mgmtCompany
        End If
      ElseIf (entityType = "Hoa") Then
        Dim model = New HoaUser
        model.m_AccountName = mgmtCompany.Value(ManagementCompanyUser.Columns.MVNETLOGIN)
        If (model.Authenticate(UserName, clientNumber, 1, Password)) Then
          HttpContext.Current.Session("CurrentUser") = model
        End If
      End If

      If (HttpContext.Current.Session("CurrentUser") Is Nothing) Then
        Flash.Error("Invalid username or password")
        Return False
      End If

      Return True
    End Function

    Public Shared Sub LogOut()
      HttpContext.Current.Session("CurrentUser") = Nothing
    End Sub

    ' Check session for CurrentUser and check if it is a managment company?
    '
    Public Shared Function IsManagmnetCompanyUser() As Boolean
      Dim model As MVNetBase = HttpContext.Current.Session("CurrentUser")
      Return If(model Is Nothing, False, model.GetType() = GetType(ManagementCompanyUser))
    End Function

    ' Check session for CurrentUser and check if it is a HOA?
    '
    Public Shared Function IsHoaUser() As Boolean
      Dim model As MVNetBase = HttpContext.Current.Session("CurrentUser")
      Return If(model Is Nothing, False, model.GetType() = GetType(HoaUser))
    End Function
  End Class
End Namespace