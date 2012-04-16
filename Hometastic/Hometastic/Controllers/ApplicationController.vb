Imports Hometastic.Models
Namespace Hometastic
  Public Class ApplicationController
    Inherits System.Web.Mvc.Controller
    Dim m_CurrentUser As MVNetBase = Nothing

    Function CurrentUser()
      If m_CurrentUser Is Nothing Then
        m_CurrentUser = Session("CurrentUser")
      End If
      Return m_CurrentUser
    End Function
  End Class
End Namespace
