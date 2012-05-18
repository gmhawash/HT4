Namespace Hometastic
    Public Class ErrorController
        Inherits System.Web.Mvc.Controller


    ' GET: /Error

        Function Index() As ActionResult
            Return View()
        End Function

        '
        ' GET: /Error/Details/5

    Function HttpError() As ActionResult
      Dim ex As Exception
      Try
        ex = HttpContext.Application(Request.UserHostAddress.ToString())
      Catch
      End Try

      ViewBag.ErrorMessage = "What up doc; something went wrong"
      Return View()
    End Function

    Function Http404() As ActionResult
      ViewBag.ErrorMessage = "Cannt find you dude"
      Return View()
    End Function
    '
    ' GET: /Error/Create

        Function Create() As ActionResult
            Return View()
        End Function

        '
        ' POST: /Error/Create

        <HttpPost> _
        Function Create(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
        
        '
        ' GET: /Error/Edit/5

        Function Edit(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        '
        ' POST: /Error/Edit/5

        <HttpPost> _
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        '
        ' GET: /Error/Delete/5

        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        '
        ' POST: /Error/Delete/5

        <HttpPost> _
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
