Imports System.Collections
Public Class HomeController
  Inherits System.Web.Mvc.Controller

  Function Index() As ActionResult
    ViewBag.Menu = {({"Account", "Index", "Home"}),
                    ({"Something", "Else", "Home"})}



    Return View()
  End Function

  Function About() As ActionResult
    Return View()

  End Function
End Class
