Imports Hometastic.Models
Imports BlueFinity.mvNET.CoreObjects

Namespace Hometastic
  Public Class VendorController
    Inherits System.Web.Mvc.Controller

    ' GET: /Hoa

    Function Index() As ActionResult
      Return View()
    End Function

    '
    ' GET: /Hoa/Details/5

    Function Details(ByVal id As Integer) As ActionResult
      Return View()
    End Function

    '
    ' GET: /Hoa/Create

    Function Create() As ActionResult
      Return View()
    End Function

    '
    ' POST: /Hoa/Create

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
    ' GET: /Hoa/Edit/5

    Function Edit(ByVal id As Integer) As ActionResult
      Return View()
    End Function

    '
    ' POST: /Hoa/Edit/5

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
    ' GET: /Hoa/Delete/5

    Function Delete(ByVal id As Integer) As ActionResult
      Return View()
    End Function

    '
    ' POST: /Hoa/Delete/5

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
