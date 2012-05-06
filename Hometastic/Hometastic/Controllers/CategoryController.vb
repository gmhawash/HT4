Imports Hometastic.Models
Imports BlueFinity.mvNET.CoreObjects

Namespace Hometastic
  Public Class CategoryController
    Inherits ApplicationController
    '
    ' GET: /Category
    ' Hoa/605/Category/Index
    Function Index() As ActionResult
      ViewBag.CategoryList = HoaUser.Categories
      Return View()
    End Function

    '
    ' GET: /Category/Create

    Function Create() As ActionResult
      Return View(New Category(HoaUser))
    End Function

    '
    ' POST: /Category/Create

    <HttpPost()> _
    Function Create(ByVal collection As FormCollection) As ActionResult
      Dim cat = Category.Create(Of Category)(HoaUser)
      collection("ID") = cat.NextId()
      cat.Write(collection)
      Response.StatusCode = 200
      Response.ContentType = "text/html"
      Return Json(New With {.success = True})
    End Function

    '
    ' GET: /Category/Edit/5

    Function Edit(ByVal id As String) As ActionResult
      Dim item = Category.FindById(HoaUser, id)
      Return View(item)
    End Function

    '
    ' POST: /Category/Edit/5

    <HttpPost()> _
    Function Edit(ByVal id As String, ByVal collection As FormCollection) As ActionResult
      Try
        Dim item = Category.FindById(HoaUser, id)
        item.Write(collection)
        Response.StatusCode = 200
        Response.ContentType = "text/html"
        Return Json(New With {.success = True})
      Catch
        Return View()
      End Try
    End Function

    ''
    '' POST: /Category/Delete/5

    '<HttpPost()> _
    'Function Delete(ByVal id As String) As ActionResult
    '  Try
    '    ' TODO: Add delete logic here
    '    If Not id = "" Then
    '      Dim newsItem = Category.FindById(Of Category)(id.Replace("_", "*"))
    '      newsItem.Delete()
    '    End If

    '    Return RedirectToAction("Index")
    '  Catch
    '    Return View()
    '  End Try
    'End Function
  End Class
End Namespace
