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

    Public Property AnswerOptions()
      Get
        Dim answerList = Value("ANSWERTEXT").Split(DataBASIC.VM)
        Return answerList
      End Get
      Set(ByVal value)
        Dim list As List(Of String) = New List(Of String)
        For Each item In value
          list.Add(item)
        Next
        m_mvItem("ANSWERTEXT") = String.Join(DataBASIC.VM, list)
      End Set
    End Property

    Public Property AnswerType() As String
      Get
        Dim optionTypes() As String = {"checkbox", "radio", "select"}
        Return optionTypes(Convert.ToInt16(Value(Columns.ANSWERTYPE)) - 1)
      End Get

      Set(ByVal value As String)
        Select Case (value)
          Case "select"
            m_mvItem("ANSWERTYPE") = 1
          Case "checkbox"
            m_mvItem("ANSWERTYPE") = 2
          Case "radio"
            m_mvItem("ANSWERTYPE") = 3
        End Select
      End Set
    End Property

    Public Property QuestionText() As String
      Get
        Return Value("QUESTIONTEXT")
      End Get
      Set(ByVal value As String)
        m_mvItem("QUESTIONTEXT") = value
      End Set
    End Property

    Public ReadOnly Property QuestionId() As String
      Get
        Return Id()
      End Get
    End Property

    Shared Function AnswerTypeOptions() As List(Of SelectListItem)
      Dim list As List(Of SelectListItem) = New List(Of SelectListItem)
      list.Add(New SelectListItem With {.Value = "checkbox", .Text = "Check boxes"})
      list.Add(New SelectListItem With {.Value = "radio", .Text = "Radio buttons"})
      list.Add(New SelectListItem With {.Value = "select", .Text = "Dropdown List"})
      Return list
    End Function

    Sub UpdateFromJson(ByVal json)
      QuestionText = json("QuestionText")
      AnswerType = json("AnswerType")
      AnswerOptions = json("AnswerOptions")
      If m_mvItem.ID = "" Then m_mvItem.ID = NextId()
      Write()
    End Sub

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
      Return String.Format("{0}*{1}", m_CurrentUser.Id, NextId(String.Format("WITH MGMTCONO = ""{0}""", m_CurrentUser.Id)))
    End Function

    Overloads Sub Write(ByVal record As FormCollection)
      If m_mvItem.ID Is Nothing Then record("ID") = m_CurrentUser.Id & "*" & NextId()
      MyBase.Write(record)
    End Sub
  End Class
End Namespace

