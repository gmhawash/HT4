Imports Hometastic.Models
Imports BlueFinity.mvNET.CoreObjects
Imports System.Web.Script.Serialization


Namespace Hometastic
  Public Class QuestionController
    Inherits ApplicationController
    '
    ' GET: /News
    Function Index() As ActionResult
      Return View()
    End Function

    Function QuestionList()
      Response.StatusCode = 200
      Return Json(CurrentAccount.QuestionList, JsonRequestBehavior.AllowGet)
    End Function

    '
    ' POST: /News/Create

    <HttpPost()> _
    Function Create(ByVal collection As FormCollection) As ActionResult
      Try
        Dim q As String = collection("questions")
        Dim jsonSerializer As JavaScriptSerializer = New JavaScriptSerializer
        Dim items = jsonSerializer.DeserializeObject(q)

        Dim surveyItem As Question
        For Each item In items
          If Not item("Id") = "" Then
            surveyItem = Question.FindById(CurrentAccount, item("Id").Replace("_", "*"))
          Else
            surveyItem = New Question(CurrentAccount)
            surveyItem.CreateNewMvItem(CurrentAccount)
          End If
          surveyItem.UpdateFromJson(item)
        Next
      Catch
      End Try
      Return (RedirectToAction("Index"))
    End Function

    '
    ' GET: /News/Delete/5
    Function Delete(ByVal id As Integer) As ActionResult
      Return View()
    End Function

    '
    ' POST: /News/Delete/5

    <HttpPost()> _
    Function Delete(ByVal id As String) As ActionResult
      Try
        ' TODO: Add delete logic here
        If Not id = "" Then
          Dim surveyItem = Question.FindById(CurrentAccount, id.Replace("_", "*"))
          surveyItem.Delete()
        End If

        Return Json(New With {.success = True})
      Catch
        Return Json(New With {.success = False})
      End Try
    End Function
  End Class
End Namespace
