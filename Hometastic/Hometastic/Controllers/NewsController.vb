Imports Hometastic.Models
Imports BlueFinity.mvNET.CoreObjects

Namespace Hometastic
  Public Class NewsController
    Inherits System.Web.Mvc.Controller
    Dim CurrentUser As MVNetBase

    Sub SetupMenu()
      ViewBag.Menu = {({"My Account", "/ManagementCompany/Index"}),
                      ({"Manage Site", "/ManagementCompany/Edit"}),
                      ({"News", "/News/Index"}),
                      ({"Q&A", "/ManagementCompany/Survey"})
                     }

      Account.Authenticate("6400", "pmsi", "", "ManagementCompany")
      CurrentUser = Session("CurrentUser")
    End Sub
    '
    ' GET: /News

    Function Index() As ActionResult
      SetupMenu()
      ViewBag.NewsList = CurrentUser.NewsList
      Return View()
    End Function

    '
    ' GET: /News/Details/5
    Function Details(ByVal id As Integer) As ActionResult
      Return View()
    End Function

    '
    ' GET: /News/Create

    Function Create() As ActionResult
      SetupMenu()
      Return View(New News())
    End Function

    '
    ' POST: /News/Create

    <HttpPost()> _
    Function Create(ByVal collection As FormCollection) As ActionResult
      Try
        SetupMenu()
        Dim newsItem = New News(CurrentUser)
        newsItem.Write(collection)
        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function

    '
    ' GET: /News/Edit/5

    Function Edit(ByVal id As Integer) As ActionResult
      Return View()
    End Function

    '
    ' POST: /News/Edit/5

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
    ' GET: /News/Delete/5

    Function Delete(ByVal id As Integer) As ActionResult
      Return View()
    End Function

    '
    ' POST: /News/Delete/5

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
