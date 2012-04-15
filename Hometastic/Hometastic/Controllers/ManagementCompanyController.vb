Imports Hometastic.Models
Imports BlueFinity.mvNET.CoreObjects
Imports System
Imports System.IO
Imports System.Text

Namespace Hometastic
  Public Class ManagementCompanyController
    Inherits System.Web.Mvc.Controller

    Dim CurrentUser As ManagementCompanyUser

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
    ' GET: /ManagementCompany

    Function Index() As ActionResult
      SetupMenu()
      ViewBag.VendorList = CurrentUser.VendorList()
      ViewBag.HoaList = CurrentUser.HoaList()
      Return View(CurrentUser)
    End Function

    '
    ' GET: /ManagementCompany/Edit/5

    Function Edit() As ActionResult
      Account.Authenticate("6400", "pmsi", "", "ManagementCompany")
      SetupMenu()
      Return View(CurrentUser)
    End Function

    '
    ' POST: /ManagementCompany/Edit/5

    <HttpPost()> _
    Function Edit(ByVal collection As FormCollection) As ActionResult
      Try
        SetupMenu()
        CurrentUser.Write(collection)
        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function

    <HttpPost()> _
    Function Upload(ByVal collection As FormCollection) As ActionResult
      Dim writer As FileStream
      SetupMenu()

      ' TODO: Delete exisiting images of same pattern.

      Dim extension = Request.Headers("X-File-Name").Split(".").Last()
      Dim path = MyConfiguration.PhysicalAssetPath(Request.Params("purpose"), CurrentUser.Value("WEBSITEPATH"), CurrentUser.Id, extension)
      writer = System.IO.File.Open(path, FileMode.Create, FileAccess.Write)

      Using inputStream As Stream = Request.InputStream
        Dim bufSize = 1024 * 1024
        Dim buff() As Byte = New Byte(bufSize) {}
        Dim count = 0

        Do
          count = inputStream.Read(buff, 0, bufSize)
          writer.Write(buff, 0, count)
        Loop While (count > 0)

        writer.Close()
      End Using
      Response.StatusCode = 200
      Response.ContentType = "text/html"
      Return Json(New With {.success = True})

      'TODO: What if it failed to upload ???

    End Function
  End Class
End Namespace
