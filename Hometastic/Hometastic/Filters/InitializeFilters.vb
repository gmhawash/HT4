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
      filterContext.Controller.ViewBag.Menu = {({"My Account", "/ManagementCompany/Index"}),
                      ({"Manage Site", "/ManagementCompany/Edit"}),
                      ({"News", "/News/Index"}),
                      ({"Q&A", "/ManagementCompany/Survey"})
                     }
      Account.Authenticate("6400", "pmsi", "", "ManagementCompany")
    End Sub
  End Class

  Public Class HoaInitializeFilter
    Inherits ActionFilterAttribute
    Public Overrides Sub OnActionExecuting(ByVal filterContext As ActionExecutingContext)
      filterContext.Controller.ViewBag.Menu = {({"My Account", "/ManagementCompany/Index"}),
                      ({"Manage Site", "/ManagementCompany/Edit"}),
                      ({"News", "/News/Index"}),
                      ({"This and That", "/ManagementCompany/Survey"})
                     }
    End Sub
  End Class
End Namespace