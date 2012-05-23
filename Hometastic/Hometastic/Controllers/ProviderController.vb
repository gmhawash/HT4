Imports Hometastic.Models
Imports BlueFinity.mvNET.CoreObjects

Namespace Hometastic
  Public Class ProviderController
    Inherits ApplicationController

    Function Index() As ActionResult
      ViewBag.NewsList = CurrentAccount.ProviderList
      Return View()
    End Function


    Function Create() As ActionResult
      Return View(New Provider())
    End Function

    <HttpPost()> _
    Function Create(ByVal collection As FormCollection) As ActionResult
      Try
        Dim item = New Provider(CurrentAccount)
        item.Write(collection)
        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function

    Function Edit(ByVal id As String) As ActionResult
      Dim item = New Provider(CurrentAccount)
      item.Read(id.Replace("_", "*")) ' Well the browser does not like splat(*), so we pacifiy it.
      Return View()
    End Function

    <HttpPost()> _
    Function Edit(ByVal id As String, ByVal collection As FormCollection) As ActionResult
      Try
        Dim item = New Provider(CurrentAccount)
        item.Read(id.Replace("_", "*")) ' Well the browser does not like splat(*), so we pacifiy it.
        item.Write(collection)
        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function

    <HttpPost()> _
    Function Delete(ByVal id As String, ByVal collection As FormCollection) As ActionResult
      Try
        Dim item = Provider.FindById(CurrentAccount, id.Replace("_", "*"))
        item.Delete()

        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function
  End Class
End Namespace
