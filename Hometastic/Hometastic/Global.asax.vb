' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802
Imports Hometastic.Models

Public Class MvcApplication
  Inherits System.Web.HttpApplication

  Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
    filters.Add(New HandleErrorAttribute())
    Dim provider As New ActionFilterProvider
    provider.Add("ManagementCompany", "*", New ManagementUserFilter)
    provider.Add("HOA", "*", New HoaUserFilter)
    FilterProviders.Providers.Add(provider)

  End Sub

  Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

    ' MapRoute takes the following parameters, in order:
    ' (1) Route name
    ' (2) URL with parameters
    ' (3) Parameter defaults
    routes.MapRoute( _
        "LogOn", _
        "", _
        New With {.controller = "Home", .action = "LogOn", .path = UrlParameter.Optional} _
    )

    routes.MapRoute( _
        "Default", _
        "{controller}/{path}", _
        New With {.controller = "Home", .action = "Index", .path = UrlParameter.Optional} _
    )

  End Sub

  Sub Application_Start()
    AreaRegistration.RegisterAllAreas()

    RegisterGlobalFilters(GlobalFilters.Filters)
    RegisterRoutes(RouteTable.Routes)
  End Sub
End Class
