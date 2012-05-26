Imports System
Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class Question
    Inherits MVNetBase

#Region "***** Table Definition ***********"
    Public Enum Columns
      QUESTIONTEXT
      ANSWERTYPE
      ANSWERTEXT
      SEQ
    End Enum

    Overrides Function TableColumns()
      m_TableName = "DWQUESTIONS"
      m_WriteableColumnList = New List(Of String)(New String() {"QUESTIONTEXT", "ANSWERTYPE", "ANSWERTEXT"})
      Return [Enum].GetValues(GetType(Columns))
    End Function


    Sub New(ByVal CurrentAccount As MVNetBase)
      MyBase.New(CurrentAccount)
    End Sub

    Sub New(ByVal item As mvItem)
      MyBase.New(item)
    End Sub

    Overloads Shared Function FindById(ByRef CurrentAccount As HoaUser, ByVal Id As String)
      Return MVNetBase.FindById(New Question(CurrentAccount), Id)
    End Function

    Overloads Function Id()
      Return m_mvItem.ID.Replace("*", "_")
    End Function

    Overloads Function NextId()
      Return String.Format("{0}*{1}", m_CurrentUser.Id, NextId(String.Format("WITH MGMTCONO = ""{0}""", m_CurrentUser.Id)))
    End Function

    Overloads Sub Write(ByVal record As FormCollection)
      If m_mvItem.ID Is Nothing Then record("ID") = m_CurrentUser.Id & "*" & NextId()
      MyBase.Write(record)
    End Sub
#End Region

#Region "***** Model Specific Properties ***********"
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
        Dim optionTypes() As String = {"select", "checkbox", "radio"}
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
#End Region

#Region "***** Model Specific Functions ***********"
    Sub UpdateFromJson(ByVal json)
      QuestionText = json("QuestionText")
      AnswerType = json("AnswerType")
      AnswerOptions = json("AnswerOptions")
      If m_mvItem.ID = "" Then m_mvItem.ID = NextId()
      Write()
    End Sub
#End Region

  End Class
End Namespace

