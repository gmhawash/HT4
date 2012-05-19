Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports Hometastic.Models

Public Class FilterProvider
  Implements IFilterProvider

  Private actions As IList(Of ControllerAction) = New List(Of ControllerAction)

  Public Sub Add(ByVal controllername As String, ByVal actionname As String, ByVal filter As FilterAttribute)
    actions.Add(New ControllerAction With
                {.ControllerName = controllername,
                 .ActionName = actionname,
                 .Context = If(filter.GetType() = GetType(ManagementCompanyInitializeFilter), "MC", "HOA"),
                 .filter = filter})
  End Sub

  Public Function GetFilters(ByVal controllerContext As ControllerContext,
                             ByVal actionDescriptor As ActionDescriptor
                             ) As IEnumerable(Of Filter) Implements IFilterProvider.GetFilters

    Dim result = New List(Of Filter)

    ' TODO: This logic is somewhat convoluted, but simple and necessary. Maybe there is a way to simplify
    For Each action As ControllerAction In actions
      If (action.ControllerName = actionDescriptor.ControllerDescriptor.ControllerName OrElse action.ControllerName = "*") AndAlso
         (action.ActionName = actionDescriptor.ActionName OrElse action.ActionName = "*") Then
        If (controllerContext.RouteData.Values("hoa_id") And action.Context = "HOA") OrElse
           (IsNothing(controllerContext.RouteData.Values("hoa_id")) And action.Context = "MC") Then
          result.Add(New Filter(action.filter, FilterScope.First, Nothing))
          Return result
          Exit For
        End If
      End If
    Next action

    Return result
  End Function

End Class

Friend Class ControllerAction
  Friend Property ControllerName As String
  Friend Property ActionName As String
  Friend Property Context As String
  Friend Property filter As FilterAttribute
End Class
