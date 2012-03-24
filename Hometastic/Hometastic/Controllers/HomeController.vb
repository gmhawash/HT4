Imports System.Collections
Public Class HomeController
  Inherits System.Web.Mvc.Controller
  Sub SetupMenu()
    ViewBag.Menu = {({"My Account", "/Home/Index"}),
                    ({"Services", "/Home/Services"}),
                    ({"Contact Us", "/Home/ContactUs"})
                   }
  End Sub

  Function Index(ByVal query As String) As ActionResult
    Dim s As String = HttpContext.Request.RequestContext.RouteData.Values("path")
    If s Is Nothing Then
      s = "Index"
    End If

    SetupMenu()
    Return View(s)
  End Function

  Function About() As ActionResult
    Return View()
  End Function

  Function ContactUs() As ActionResult
    SetupMenu()
    Return View()
  End Function

  <HttpPost()> _
  Public Function LogOn(ByVal collection As FormCollection) As ActionResult

    Return View()
  End Function

End Class
