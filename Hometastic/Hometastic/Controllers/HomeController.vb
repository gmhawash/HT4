Imports Hometastic.Models
Imports BlueFinity.mvNET.CoreObjects

Public Class HomeController
  Inherits System.Web.Mvc.Controller

  Function Index() As ActionResult
    ViewData("Message") = "Welcome to ASP.NET MVC!"

    Dim mgmt As MVNetBase = New ManagementCompany()
    Dim item As mvItem = mgmt.Read("6400")

    Dim hoa As MVNetBase = New HoaUser()
    Dim hoaUser As mvItem = hoa.Read("605")
    Return View()
  End Function

  Function About() As ActionResult
    Return View()

  End Function
End Class
