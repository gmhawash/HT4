Imports Hometastic.Models
Imports BlueFinity.mvNET.CoreObjects

Namespace Hometastic
  Public Class DocumentController
    Inherits ApplicationController
    '
    ' GET: /Document
    ' Hoa/605/Document/Index
    Function Index() As ActionResult
      ViewBag.DocumentList = HoaUser.Documents
      Return View()
    End Function

    '
    ' GET: /Document/Create

    Function Create() As ActionResult
      Return View(New Document(HoaUser))
    End Function

    '
    ' POST: /Document/Create

    <HttpPost()> _
    Function Create(ByVal collection As FormCollection) As ActionResult
      Try
        Dim newsItem = New Document(HoaUser)
        newsItem.Write(collection)
        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function

    '
    ' GET: /Document/Edit/5

    'Function Edit(ByVal id As String) As ActionResult
    '  Dim newsItem = New Document(CType(CurrentUser(), ManagementCompanyUser))
    '  newsItem.Read(id.Replace("_", "*")) ' Well the browser does not like splat(*), so we pacifiy it.
    '  Return View(newsItem)
    'End Function

    ''
    '' POST: /Document/Edit/5

    '<HttpPost()> _
    'Function Edit(ByVal id As String, ByVal collection As FormCollection) As ActionResult
    '  Try
    '    Dim newsItem = New Document(CType(CurrentUser(), ManagementCompanyUser))
    '    newsItem.Read(id.Replace("_", "*")) ' Well the browser does not like splat(*), so we pacifiy it.
    '    newsItem.Write(collection)
    '    Return RedirectToAction("Index")
    '  Catch
    '    Return View()
    '  End Try
    'End Function

    ''
    '' POST: /Document/Delete/5

    '<HttpPost()> _
    'Function Delete(ByVal id As String) As ActionResult
    '  Try
    '    ' TODO: Add delete logic here
    '    If Not id = "" Then
    '      Dim newsItem = Document.FindById(Of Document)(id.Replace("_", "*"))
    '      newsItem.Delete()
    '    End If

    '    Return RedirectToAction("Index")
    '  Catch
    '    Return View()
    '  End Try
    'End Function
  End Class
End Namespace
