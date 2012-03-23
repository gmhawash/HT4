Imports System.Collections
Public Class HomeController
  Inherits System.Web.Mvc.Controller
  Sub SetupMenu()
    ViewBag.Menu = {({"MY ACCOUNT", "Index", "Home"}),
                    ({"SERVICES", "Services", "Home"}),
                    ({"CONTACT US", "ContactUs", "Home"})
                   }
  End Sub
  Function Index() As ActionResult
    SetupMenu()
    Return View()
  End Function

  Function About() As ActionResult
    Return View()
  End Function

  Function Services() As ActionResult
    SetupMenu()
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
