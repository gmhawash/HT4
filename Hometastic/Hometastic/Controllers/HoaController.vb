Imports Hometastic.Models
Imports BlueFinity.mvNET.CoreObjects
Imports System.IO

Namespace Hometastic
  Public Class HoaController
    Inherits ApplicationController

    Function Edit(ByVal hoa_id As Integer) As ActionResult
      Return View(HoaUser())
    End Function

    <HttpPost()> _
    Function Edit(ByVal hoa_id As Integer, ByVal collection As FormCollection) As ActionResult
      Try
        HoaUser.Write(collection)
        Return View(HoaUser)
      Catch
        Return View()
      End Try
    End Function

    <HttpPost()> _
    Function Delete(ByVal hoa_id As Integer, ByVal collection As FormCollection) As ActionResult
      Try
        ' TODO: Add delete logic here

        Return RedirectToAction("Index")
      Catch
        Return View()
      End Try
    End Function

    <HttpPost()> _
    Function Upload(ByVal collection As FormCollection) As ActionResult
      Dim hoa As HoaUser = New HoaUser(Account.ManagementCompany)
      hoa.Read(Request.Params("Id"))

      DeleteFiles(hoa.AssetFolder, "logo.*")
      Dim filename = hoa.LogoPath(Request.Headers("X-File-Name"))
      UploadFile(hoa.LogoPath(filename), Request.InputStream)

      Response.StatusCode = 200
      Response.ContentType = "text/html"
      Return Json(New With {.success = True})

      'TODO: What if it failed to upload ???
    End Function
  End Class
End Namespace
