Imports System
Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class Survey
    Inherits MVNetBase

    Public Enum Columns
      ACTIVATEDATE
      CREATEDATE
      QUESTION
      SEQ
      ISCURRENT
      VOTES
      VOTESIPS
      ANSWERS
    End Enum

    Shared Function FindById(ByRef CurrentAccount, ByVal Id)
      Dim item = New Survey(CurrentAccount)
      item.Read(Id)
      Return item
    End Function

    Public Property QuestionText() As String
      Get
        Return Value("QUESTION")
      End Get
      Set(ByVal value As String)
        m_mvItem("QUESTION") = value
      End Set
    End Property

    Public Property Active() As Boolean
      Get
        Return Not ActivatedOn.ToString() = "01 Jan 01"
      End Get
      Set(ByVal value As Boolean)
        m_mvItem("QUESTION") = value
      End Set
    End Property


    Public Property Current() As Boolean
      Get
        Return Value("ISCURRENT") = "1"
      End Get
      Set(ByVal value As String)
        m_mvItem("QUESTION") = value
      End Set
    End Property
    Public Property Answers()
      Get
        Dim answerList = Value("ANSWERS").Split(DataBASIC.VM)
        Return answerList
      End Get
      Set(ByVal value)
        Dim list As List(Of String) = New List(Of String)
        For Each item In value
          list.Add(item)
        Next
        m_mvItem("ANSWERS") = String.Join(DataBASIC.VM, list)
      End Set
    End Property

    Public Property CreatedOn()
      Get
        Return Value(Columns.CREATEDATE)
      End Get
      Set(ByVal value)
        Dim list As List(Of String) = New List(Of String)
        For Each item In value
          list.Add(item)
        Next
        m_mvItem("ANSWERS") = String.Join(DataBASIC.VM, list)
      End Set
    End Property

    Public Property ActivatedOn()
      Get
        Dim activateDate = Value(Columns.ACTIVATEDATE)
        Return If(activateDate = "01 Jan 1", "", activateDate)
      End Get
      Set(ByVal value)
        Dim list As List(Of String) = New List(Of String)
        For Each item In value
          list.Add(item)
        Next
        m_mvItem("ANSWERS") = String.Join(DataBASIC.VM, list)
      End Set
    End Property

    Public ReadOnly Property QuestionId() As String
      Get
        Return Id()
      End Get
    End Property

    Sub UpdateFromJson(ByVal json)
      QuestionText = json("QuestionText")
      Answers = json("Answers")
      If m_mvItem.ID = "" Then m_mvItem.ID = NextId()
      Write()
    End Sub

    Sub New(Optional ByVal CurrentUser = Nothing)
      m_TableName = "HOASURVEY"
      If Not CurrentUser Is Nothing Then m_AccountName = CurrentUser.m_AccountName
      m_CurrentUser = CurrentUser
      ParseColumns([Enum].GetValues(GetType(Columns)))
      m_WriteableColumnList = New List(Of String)(New String() {
          "ACTIVATEDATE", "CREATEDATE", "QUESTION",
          "ISCURRENT", "VOTES", "VOTESIPS", "ANSWERS"
          })
    End Sub

    Overloads Function Id()
      Return m_mvItem.ID.Replace("*", "_")
    End Function

    Sub New(ByVal item As mvItem)
      m_mvItem = item
      ParseColumns([Enum].GetValues(GetType(Columns)))
    End Sub

    Overloads Function NextId()
      Return String.Format("{0}*{1}", m_CurrentUser.Id, NextId(String.Format("WITH HOANO = ""{0}""", m_CurrentUser.Id)))
    End Function

    Overloads Sub Write(ByVal record As FormCollection)
      If m_mvItem.ID Is Nothing Then record("ID") = m_CurrentUser.Id & "*" & NextId()
      MyBase.Write(record)
    End Sub
  End Class
End Namespace

