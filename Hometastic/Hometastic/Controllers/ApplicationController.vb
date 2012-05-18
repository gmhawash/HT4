Imports Hometastic.Models
Imports MvcFlash.Core

Namespace Hometastic
  Public Class ApplicationController
    Inherits System.Web.Mvc.Controller
    Dim m_CurrentUser As MVNetBase = Nothing
    Dim m_HoaUser As HoaUser = Nothing

    Function CurrentUser()
      If m_CurrentUser Is Nothing Then
        m_CurrentUser = Session("CurrentUser")
      End If
      Return m_CurrentUser
    End Function

    Function HoaUser() As HoaUser
      If Not m_HoaUser Is Nothing Then Return m_HoaUser

      Account.Authenticate("6400", "pmsi", "605", "ManagementCompany")

      Dim routeParams = Request.RequestContext.RouteData.Values
      m_HoaUser = New HoaUser(Account.ManagementCompany.HoaAccount())

      If routeParams("hoa_id") Is Nothing Then
        m_HoaUser.Read(routeParams("id"))
      Else
        m_HoaUser.Read(routeParams("hoa_id"))
      End If

      Return m_HoaUser
    End Function
  End Class
End Namespace
