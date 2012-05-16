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
        Dim document = New Document(HoaUser)
        collection("ID") = HoaUser.id & "*" & collection("Filename")
        FileCopy(collection("TempFilename"), HoaUser.DocumentPath(collection("Filename")))
        document.Write(collection)
        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function

    <HttpPost()> _
    Function Upload(ByVal collection As FormCollection) As ActionResult
      Try
        Dim filename = Request.Headers("X-File-Name")
        Dim tmpFile = TempFilename()
        UploadFile(tmpFile, Request.InputStream)

        Response.StatusCode = 200
        Response.ContentType = "text/html"
        Return Json(New With {.success = True, .tempFilename = tmpFile, .filename = filename})
      Catch
        Return View()
      End Try
    End Function

    '
    ' GET: /Document/Edit/5

    Function Edit(ByVal id As String) As ActionResult
      Return View(Document.FindById(HoaUser, id))
    End Function

    ''
    '' POST: /Document/Edit/5

    <HttpPost()> _
    Function Edit(ByVal id As String, ByVal collection As FormCollection) As ActionResult
      Try
        Dim doc = Document.FindById(HoaUser, id)
        If Not String.IsNullOrWhiteSpace(collection("filename")) Then
          collection("ID") = HoaUser.id & "*" & collection("Filename")
          FileCopy(collection("TempFilename"), HoaUser.DocumentPath(collection("Filename")))
        End If

        doc.Write(collection)
        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function

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
