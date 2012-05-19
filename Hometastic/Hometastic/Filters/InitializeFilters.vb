Imports MvcFlash.Core

Namespace Models
  ' This filter limits controller actions to users who log in as a management company.
  ' In web.config, the section defines where it should redirect on failed authentication:
  '  <authentication mode="Forms">
  '     <forms defaultUrl="/" loginUrl="/" timeout="2880" />
  '  </authentication>
  ' The filters are attached to the controller through the ActionFilterProvider class in global.asax .
  '
  Public Class ManagementCompanyInitializeFilter
    Inherits ActionFilterAttribute
    Public Overrides Sub OnActionExecuting(ByVal filterContext As ActionExecutingContext)
      filterContext.Controller.ViewBag.Menu = {
                      ({"My Account", "/ManagementCompany/Index"}),
                      ({"Manage Site", "/ManagementCompany/Edit"}),
                      ({"News", "/News/Index"}),
                      ({"Q&A", "/Question/Index"})
                     }
      Account.Authenticate("6400", "pmsi", "", "ManagementCompany")
    End Sub
  End Class

  Public Class HoaInitializeFilter
    Inherits ActionFilterAttribute
    Public Overrides Sub OnActionExecuting(ByVal filterContext As ActionExecutingContext)

      Dim routeParams = filterContext.RouteData.Values
      Dim hoa_id = If(routeParams("hoa_id") Is Nothing, routeParams("id"), routeParams("hoa_id"))

      filterContext.Controller.ViewBag.Menu = {
                      ({"Mgmt Co.", "/ManagementCompany/Index"}),
                      ({"Manage Hoa", "/Hoa/Edit/{hoa_id}"}),
                      ({"News", "/Hoa/{hoa_id}/News/Index"}),
                      ({"Events", "/Hoa/{hoa_id}/Events/Index"}),
                      ({"Surveys", "/Hoa/{hoa_id}/Survey/Index"}),
                      ({"Providers", "/Hoa/{hoa_id}/Providers/Index"}),
                      ({"Documents", "/Hoa/{hoa_id}/Document/Index"})
                     }

      ' Update menu items with hoa_id
      For Each Item As String() In filterContext.Controller.ViewBag.Menu
        Item(1) = Item(1).Replace("{hoa_id}", hoa_id)
      Next

    End Sub
  End Class
End Namespace