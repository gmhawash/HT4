' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802

Imports Hometastic.Models
Imports MvcFlash.Core

Public Class MvcApplication
  Inherits System.Web.HttpApplication

  Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
    filters.Add(New HandleErrorAttribute())
    Dim provider As New FilterProvider
    'provider.Add("ManagementCompany", "*", New ManagementUserFilter)
    'provider.Add("Hoa", "*", New HoaUserFilter)

    provider.Add("Home", "*", New ManagementCompanyInitializeFilter)
    provider.Add("ManagementCompany", "*", New ManagementCompanyInitializeFilter)
    provider.Add("News", "*", New ManagementCompanyInitializeFilter)
    provider.Add("Question", "*", New ManagementCompanyInitializeFilter)

    provider.Add("Hoa", "*", New HoaInitializeFilter)
    provider.Add("Survey", "*", New HoaInitializeFilter)
    provider.Add("News", "*", New HoaInitializeFilter)
    provider.Add("Document", "*", New HoaInitializeFilter)
    FilterProviders.Providers.Add(provider)
  End Sub

  Shared Sub MapResource(ByVal resource As String)
    RouteTable.Routes.MapRoute(resource, resource & "/{action}/{id}", New With {.controller = resource, .id = UrlParameter.Optional})
  End Sub

  Shared Sub MapResource(ByVal scope As String, ByVal resource As String)
    RouteTable.Routes.MapRoute(scope & resource, String.Format("{0}/{{{1}_id}}/{2}/{{action}}/{{id}}", scope, scope.ToLower(), resource), New With {.controller = resource, .id = UrlParameter.Optional})
  End Sub

  Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

    ' MapRoute takes the following parameters, in order:
    ' (1) Route name
    ' (2) URL with parameters
    ' (3) Parameter defaults
    'routes.MapRoute("LogOn", "", New With {.controller = "Home", .action = "LogOn", .path = UrlParameter.Optional})
    routes.MapRoute("LogOn", "", New With {.controller = "ManagementCompany", .action = "Edit", .path = UrlParameter.Optional})
    routes.MapRoute("Hoa", "Hoa/{action}/{hoa_id}", New With {.controller = "Hoa"})
    MapResource("Hoa", "Document")
    MapResource("Hoa", "Category")
    MapResource("Hoa", "News")
    MapResource("Hoa", "Survey")

    MapResource("ManagementCompany")
    MapResource("Vendor")
    MapResource("News")
    MapResource("Question")

    routes.MapRoute("Error",
                    "Error/{action}",
                    New With {.controller = "Error"}
                    )
    routes.MapRoute("Default",
                    "{controller}/{path}",
                    New With {.controller = "Home", .action = "Index", .path = UrlParameter.Optional}
                    )
    ' NOTE: This line is used for debugging routes; remove it when you are done debugging.
    ' RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes)
  End Sub

  Sub Application_Start()
    AreaRegistration.RegisterAllAreas()

    RegisterGlobalFilters(GlobalFilters.Filters)
    RegisterRoutes(RouteTable.Routes)
    MyConfiguration.Load()
  End Sub

  Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
    Dim ex As Exception = Server.GetLastError()
    Application(HttpContext.Current.Request.UserHostAddress.ToString()) = ex
  End Sub
End Class
