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
    ' GET: /News/Create

    Function Create() As ActionResult
      Return View()
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
    ' GET: /News/Delete/5

    Function Delete(ByVal id As Integer) As ActionResult
      Return View()
    End Function

    '
    ' POST: /News/Delete/5

    <HttpPost()> _
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
