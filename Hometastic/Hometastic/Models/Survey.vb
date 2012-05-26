Imports System
Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class Survey
    Inherits MVNetBase

#Region "***** Table Definition ***********"
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

    Overrides Function TableColumns()
      m_TableName = "HOASURVEY"
      m_WriteableColumnList = New List(Of String)(New String() {
          "ACTIVATEDATE", "CREATEDATE", "QUESTION",
          "ISCURRENT", "VOTES", "VOTESIPS", "ANSWERS"
          })
      Return [Enum].GetValues(GetType(Columns))
    End Function

    Sub New(ByVal CurrentAccount As MVNetBase)
      MyBase.New(CurrentAccount)
    End Sub

    Sub New(ByVal item As mvItem)
      MyBase.New(item)
    End Sub

    Overloads Shared Function FindById(ByRef CurrentAccount As HoaUser, ByVal Id As String)
      Return MVNetBase.FindById(New Survey(CurrentAccount), Id)
    End Function

    Overloads Function Id()
      Return m_mvItem.ID.Replace("*", "_")
    End Function

    Overloads Function NextId()
      Return String.Format("{0}*{1}", m_CurrentUser.Id, NextId(String.Format("WITH HOANO = ""{0}""", m_CurrentUser.Id)))
    End Function

    Overloads Sub Write(ByVal record As FormCollection)
      If m_mvItem.ID Is Nothing Then record("ID") = m_CurrentUser.Id & "*" & NextId()
      MyBase.Write(record)
    End Sub

#End Region

#Region "***** Model Specific Properties ***********"
    Public Property QuestionText() As String
      Get
        Return Value("QUESTION")
      End Get
      Set(ByVal value As String)
        m_mvItem("QUESTION") = value
      End Set
    End Property

    Public Property Current() As Boolean
      Get
        Return Value("ISCURRENT") = "1"
      End Get
      Set(ByVal value As Boolean)
        m_mvItem("ISCURRENT") = If(value, "1", "0")
      End Set
    End Property

    Public Property Active() As Boolean
      Get
        Return Not String.IsNullOrEmpty(ActivatedOn)
      End Get
      Set(ByVal value As Boolean)
        If (value And ActivatedOn = "") Then
          Dim ts As TimeSpan = Date.Today - New Date(1967, 12, 31)
          ActivatedOn = ts.Days.ToString()
        ElseIf (value = False And Not String.IsNullOrEmpty(ActivatedOn)) Then
          Dim ts As TimeSpan = Date.MinValue - New Date(1967, 12, 31)
          ActivatedOn = ts.Days.ToString()
        End If
      End Set
    End Property


    ' NOTE: I am not sure what's going with the dates, but it appears that the 
    ' date values are being interpreted by someone (MV.NET or backend).  The db
    ' returns a date (which is supposed to be the date 1/1/0001), but .net
    ' interprets it as 1/1/2001, so any date before that is considered inactive.
    '

    ' We are also forced to write directly to item(2) which is the index of the
    ' activation date in raw format, because writing through MV.NET dictionary 
    ' fails as it tries to interpret it somehow.
    '
    Public Property ActivatedOn()
      Get
        Dim activateDate As Date
        Date.TryParse(Value(Columns.ACTIVATEDATE), activateDate)
        Return If(activateDate < New Date(2002, 12, 31), "", Value(Columns.ACTIVATEDATE))
      End Get
      Set(ByVal value)
        m_mvItem(2) = value
      End Set
    End Property

    Public Property CreatedOn()
      Get
        Return Value(Columns.CREATEDATE)
      End Get
      Set(ByVal value)
        m_mvItem(Columns.CREATEDATE) = value
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

    Public ReadOnly Property QuestionId() As String
      Get
        Return Id()
      End Get
    End Property

#End Region

#Region "***** Model Specific Functions ***********"
    Sub UpdateFromJson(ByVal json)
      QuestionText = json("QuestionText")
      Answers = json("Answers")
      Active = json("Active")
      Current = json("Current")
      If m_mvItem.ID = "" Then m_mvItem.ID = NextId()
      Write()
    End Sub

#End Region
  End Class

End Namespace

