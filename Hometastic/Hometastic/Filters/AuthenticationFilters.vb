Imports MvcFlash.Core

Namespace Models
  ' This filter limits controller actions to users who log in as a management company.
  ' In web.config, the section defines where it should redirect on failed authentication:
  '  <authentication mode="Forms">
  '     <forms defaultUrl="/" loginUrl="/" timeout="2880" />
  '  </authentication>
  ' The filters are attached to the controller through the ActionFilterProvider class in global.asax .
  '
  Public Class ManagementUserFilter
    Inherits AuthorizeAttribute
    Public Overrides Sub OnAuthorization(ByVal filterContext As AuthorizationContext)
      If (Not Account.IsManagmnetCompanyUser()) Then
        filterContext.Result = New HttpUnauthorizedResult()
        Flash.Error("Insufficent Privilages.  You must login to access this area.")
        Return
      End If

    End Sub
  End Class


  ' This filter limits controller actions to users who log in as a management company or HOA user.
  Public Class HoaUserFilter
    Inherits AuthorizeAttribute
    Public Overrides Sub OnAuthorization(ByVal filterContext As AuthorizationContext)
      If (Not (Account.IsHoaUser() Or Account.IsManagmnetCompanyUser)) Then
        filterContext.Result = New HttpUnauthorizedResult()
        Flash.Error("Insufficent Privilages.  You must login to access this area.")
        Return
      End If
    End Sub
  End Class

End Namespace
