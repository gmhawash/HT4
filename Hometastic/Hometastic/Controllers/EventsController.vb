Imports Hometastic.Models
Imports BlueFinity.mvNET.CoreObjects

Namespace Hometastic
  Public Class EventsController
    Inherits ApplicationController

    Function Index() As ActionResult
      ViewBag.EventsList = CurrentAccount.EventsList
      Return View()
    End Function

    ' GET: /Event/Create
    Function Create() As ActionResult
      Return View(New Events(CurrentAccount))
    End Function

    ' POST: /Event/Create
    <HttpPost()> _
    Function Create(ByVal collection As FormCollection) As ActionResult
      Try
        Dim item = New Events(CurrentAccount)
        item.Write(collection)
        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function

    ' GET: /Event/Edit/5
    Function Edit(ByVal id As String) As ActionResult
      Dim item = New Events(CurrentAccount)
      item.Read(id.Replace("_", "*")) ' Well the browser does not like splat(*), so we pacifiy it.
      Return View(item)
    End Function

    ' POST: /Event/Edit/5
    <HttpPost()> _
    Function Edit(ByVal id As String, ByVal collection As FormCollection) As ActionResult
      Try
        Dim item = New Events(CurrentAccount)
        item.Read(id.Replace("_", "*")) ' Well the browser does not like splat(*), so we pacifiy it.
        item.Write(collection)
        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function

    '
    ' POST: /Event/Delete/5

    <HttpPost()> _
    Function Delete(ByVal id As String) As ActionResult
      Try
        ' TODO: Add delete logic here
        If Not id = "" Then
          Dim item = Events.FindById(CurrentAccount, id.Replace("_", "*"))
          item.Delete()
        End If

        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function
  End Class
End Namespace
