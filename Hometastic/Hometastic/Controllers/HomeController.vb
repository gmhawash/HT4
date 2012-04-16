Imports System.Collections
Imports Hometastic.Models

Namespace Hometastic
  Public Class HomeController
    Inherits ApplicationController

    Function Index(ByVal query As String) As ActionResult
      Dim s As String = HttpContext.Request.RequestContext.RouteData.Values("path")
      If s Is Nothing Then
        s = "Index"
      End If

      Return View(s)
    End Function

    Public Function LogOn() As ActionResult
      Return View("Index")
    End Function
    <HttpPost()> _
    Public Function LogOn(ByVal collection As FormCollection) As ActionResult

      If Account.Authenticate(collection("mgmtCoId"), collection("password"), collection("clientNumber"), collection("userType")) Then
        Return RedirectToAction("Index", collection("userType"))
      End If

      Return RedirectToAction("LogOn")
    End Function

    <HttpPost()> _
    Public Function ContactUs(ByVal collection As FormCollection) As ActionResult

      Return View()
    End Function

  End Class
End Namespace
