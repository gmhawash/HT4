Namespace Models
  Public Class ManagementUserFilter
    Inherits AuthorizeAttribute
    Public Overrides Sub OnAuthorization(ByVal filterContext As AuthorizationContext)
      MyBase.OnAuthorization(filterContext)
      If (Not Account.ManagmnetCompany()) Then
        Dim route As RouteValueDictionary = New RouteValueDictionary()
        route.Add("controller", "Home")
        route.Add("path", "LogOn")
        filterContext.Result = New HttpUnauthorizedResult()
      End If
    End Sub
  End Class



End Namespace
