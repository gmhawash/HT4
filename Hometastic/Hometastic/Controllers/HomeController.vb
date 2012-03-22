Imports System.Collections
Public Class HomeController
  Inherits System.Web.Mvc.Controller

  Function Index() As ActionResult
    ViewBag.Menu = {({"MY ACCOUNT", "Index", "Home"}),
                    ({"SERVICES", "Else", "Home"}),
                    ({"CONTACT US", "Else", "Home"})
                   }



    Return View()
  End Function

  Function About() As ActionResult
    Return View()

  End Function

  <HttpPost()> _
  Public Function LogOn(ByVal collection As FormCollection) As ActionResult

    Return View()
  End Function

End Class
