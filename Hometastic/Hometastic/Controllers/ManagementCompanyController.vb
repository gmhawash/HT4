Imports Hometastic.Models
Imports BlueFinity.mvNET.CoreObjects

Namespace Hometastic
  Public Class ManagementCompanyController
    Inherits System.Web.Mvc.Controller

    Dim CurrentUser As ManagementCompanyUser

    Sub SetupMenu()
      ViewBag.Menu = {({"My Account", "/ManagementCompany/Index"}),
                      ({"Manage Site", "/ManagementCompany/Manage"}),
                      ({"News", "/ManagementCompany/News"}),
                      ({"Q&A", "/ManagementCompany/Survey"})
                     }

      CurrentUser = Session("CurrentUser")
    End Sub
    '
    ' GET: /ManagementCompany

    Function Index() As ActionResult
      SetupMenu()
      ViewBag.HoaList = CurrentUser.HoaList()
      'ViewBag.BannerVendors = 
      Return View()
    End Function

    '
    ' GET: /ManagementCompany/Details/5

    Function Details(ByVal id As Integer) As ActionResult
      Return View()
    End Function

    '
    ' GET: /ManagementCompany/Create

    Function Create() As ActionResult
      Return View()
    End Function

    '
    ' POST: /ManagementCompany/Create

    <HttpPost()> _
    Function Create(ByVal collection As FormCollection) As ActionResult
      Try
        ' TODO: Add insert logic here
        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function

    '
    ' GET: /ManagementCompany/Edit/5

    Function Edit(ByVal id As Integer) As ActionResult
      Return View()
    End Function

    '
    ' POST: /ManagementCompany/Edit/5

    <HttpPost()> _
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
      Try
        ' TODO: Add update logic here

        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function

    '
    ' GET: /ManagementCompany/Delete/5

    Function Delete(ByVal id As Integer) As ActionResult
      Return View()
    End Function

    '
    ' POST: /ManagementCompany/Delete/5

    <HttpPost()> _
    Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
      Try
        ' TODO: Add delete logic here

        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function
  End Class
End Namespace
