Imports Hometastic.Models
Imports BlueFinity.mvNET.CoreObjects

Namespace Hometastic
  Public Class ManagementCompanyController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /ManagementCompany

    Function Index() As ActionResult
      Dim mgmt As MVNetBase = New ManagementCompany()
      Dim item As mvItem = mgmt.Read("6400")

      Dim hoa As MVNetBase = New HoaUser()
      Dim hoaUser As mvItem = hoa.Read("605")
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
