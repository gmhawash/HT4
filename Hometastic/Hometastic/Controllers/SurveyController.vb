Imports Hometastic.Models
Imports BlueFinity.mvNET.CoreObjects
Imports System.Web.Script.Serialization


Namespace Hometastic
  Public Class SurveyController
    Inherits ApplicationController
    '
    ' GET: /News
    Function Index() As ActionResult
      Return View()
    End Function

    Function SurveyList()
      Response.StatusCode = 200
      Return Json(CurrentUser.SurveyList, JsonRequestBehavior.AllowGet )
    End Function

    '
    ' POST: /News/Create

    <HttpPost()> _
    Function Create(ByVal collection As FormCollection) As ActionResult
      Try
        Dim question As String = collection("questions")
        Dim jsonSerializer As JavaScriptSerializer = New JavaScriptSerializer
        Dim items = jsonSerializer.DeserializeObject(question)

        Dim surveyItem As Survey
        For Each item In items
          If Not item("Id") = "" Then
            surveyItem = Survey.FindById(Of ManagementCompany.Survey)(item("Id").Replace("_", "*"))
          Else
            surveyItem = Survey.Create(Of ManagementCompany.Survey)(CurrentUser)
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
          Dim surveyItem = Survey.FindById(Of ManagementCompany.Survey)(id.Replace("_", "*"))
          surveyItem.Delete()
        End If

        Return Json(New With {.success = True})
      Catch
        Return Json(New With {.success = False})
      End Try
    End Function
  End Class
End Namespace
