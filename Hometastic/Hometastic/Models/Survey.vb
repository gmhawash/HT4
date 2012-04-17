Imports System
Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class Survey
    Inherits MVNetBase

    Public Enum Columns
      QUESTIONTEXT
      ANSWERTYPE
      ANSWERTEXT
      SEQ
    End Enum

    Public ReadOnly Property AnswerOptions()
      Get
        Dim answerList = Value("ANSWERTEXT").Split(DataBASIC.VM)
        Return answerList
      End Get
    End Property

    Public ReadOnly Property AnswerType() As String
      Get
        Dim optionTypes() As String = {"checkbox", "radio", "select"}
        Return optionTypes(Convert.ToInt16(Value(Columns.ANSWERTYPE)) - 1)
      End Get
    End Property

    Public ReadOnly Property QuestionText() As String
      Get
        Return Value("QUESTIONTEXT")
      End Get
    End Property

    Shared Function AnswerTypeOptions() As List(Of SelectListItem)
      Dim list As List(Of SelectListItem) = New List(Of SelectListItem)
      list.Add(New SelectListItem With {.Value = "checkbox", .Text = "Check boxes"})
      list.Add(New SelectListItem With {.Value = "radio", .Text = "Radio buttons"})
      list.Add(New SelectListItem With {.Value = "select", .Text = "Dropdown List"})
      Return list
    End Function

    Sub New(Optional ByRef CurrentUser As MVNetBase = Nothing)
      m_TableName = "DWQUESTIONS"
      If Not CurrentUser Is Nothing Then m_AccountName = CurrentUser.m_AccountName
      m_CurrentUser = CurrentUser
      ParseColumns([Enum].GetValues(GetType(Columns)))
      m_WriteableColumnList = New List(Of String)(New String() {"QUESTIONTEXT", "ANSWERTYPE", "ANSWERTEXT"})
    End Sub

    Overloads Function Id()
      Return m_mvItem.ID.Replace("*", "_")
    End Function

    Sub New(ByVal item As mvItem)
      m_mvItem = item
      ParseColumns([Enum].GetValues(GetType(Columns)))
    End Sub

    Overloads Function NextId()
      Return NextId(String.Format("WITH MGMTCONO = ""{0}""", m_CurrentUser.Id))
    End Function

    Overloads Sub Write(ByVal record As FormCollection)
      If m_mvItem.ID Is Nothing Then record("ID") = m_CurrentUser.Id & "*" & NextId()
      MyBase.Write(record)
    End Sub


  End Class
End Namespace

