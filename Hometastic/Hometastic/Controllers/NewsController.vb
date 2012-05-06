Imports Hometastic.Models
Imports BlueFinity.mvNET.CoreObjects

Namespace Hometastic
  Public Class NewsController
    Inherits ApplicationController
    '
    ' GET: /News
    ' ManagementCompany/6400/NewsList
    ' HOA/605/NewsList
    Function Index() As ActionResult
      ViewBag.NewsList = CurrentUser.NewsList
      Return View()
    End Function

    '
    ' GET: /News/Create

    Function Create() As ActionResult
      Return View(New News())
    End Function

    '
    ' POST: /News/Create

    <HttpPost()> _
    Function Create(ByVal collection As FormCollection) As ActionResult
      Try
        Dim newsItem = New News(CType(CurrentUser(), ManagementCompanyUser))
        newsItem.Write(collection)
        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function

    '
    ' GET: /News/Edit/5

    Function Edit(ByVal id As String) As ActionResult
      Dim newsItem = New News(CType(CurrentUser(), ManagementCompanyUser))
      newsItem.Read(id.Replace("_", "*")) ' Well the browser does not like splat(*), so we pacifiy it.
      Return View(newsItem)
    End Function

    '
    ' POST: /News/Edit/5

    <HttpPost()> _
    Function Edit(ByVal id As String, ByVal collection As FormCollection) As ActionResult
      Try
        Dim newsItem = New News(CType(CurrentUser(), ManagementCompanyUser))
        newsItem.Read(id.Replace("_", "*")) ' Well the browser does not like splat(*), so we pacifiy it.
        newsItem.Write(collection)
        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function

    '
    ' POST: /News/Delete/5

    <HttpPost()> _
    Function Delete(ByVal id As String) As ActionResult
      Try
        ' TODO: Add delete logic here
        If Not id = "" Then
          Dim newsItem = News.FindById(id.Replace("_", "*"))
          newsItem.Delete()
        End If

        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function
  End Class
End Namespace
