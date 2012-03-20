Imports Hometastic.Models
Imports BlueFinity.mvNET.CoreObjects

Public Class HomeController
  Inherits System.Web.Mvc.Controller
  Dim repo As MVNetBase = New DwMaster()

  Function Index() As ActionResult
    ViewData("Message") = "Welcome to ASP.NET MVC!"

    Dim item As mvItem = repo.Read("6400")

    Return View()
  End Function

  Function About() As ActionResult
    Return View()

  End Function
End Class
