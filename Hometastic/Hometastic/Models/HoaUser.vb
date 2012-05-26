Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class HoaUser
    Inherits MVNetBase
    Dim m_documentList As List(Of Document) = Nothing
    Dim m_categoryList As List(Of Category) = Nothing
    Dim m_NewsList As List(Of News) = Nothing
    Dim m_EventsList As List(Of Events) = Nothing
    Dim m_SurveyList As List(Of Survey) = Nothing
    Dim m_ProviderList As List(Of Provider) = Nothing

#Region "***** Table Definition ***********"
    Public Enum Columns
      DISKQUOTA
      HOANO
      HOANAME
      HOAEMAIL
      HOADPASSWORD
      HOAADD1
      HOAADD2
      HOACSZ
      HOAPHONE
      HOAFAX
      CONTACTADD1
      CONTACTADD2
      SHOWEMAIL
      CADD1
      CADD2
      CCITY
      CST
      CONTACTPHONE
      CONTACTFAX
      CONTACTZIP
      CONTACTZIPCODE
      CONTACTCSZ
      CONTACTEMAIL
      SHOWMGMTCOLOGO
      WEBMASTERNAME
      WEBMASTEREMAIL
      CREDITCARDLINKURL
      ECHECKLINKURL
      DOCUMENTSLINKURL
      OTHERLINKURL
      LASTLOGINDATETIME
      WEBSITEPATH
      WEBSITECREATEDATE
      WEBSITEURL
      HASIMAGE
      TEXTWELCOME
      THEMENAME
    End Enum

    Overrides Function TableColumns()
      m_TableName = "DWMASTER"
      m_WriteableColumnList = New List(Of String)(New String() _
      {"DISKQUOTA", "CADD1", "CADD2", "CCITY", "CST", "CONTACTPHONE", "CONTACTFAX",
      "CONTACTZIPCODE", "CONTACTEMAIL", "SHOWEMAIL", "SHOWMGMTCOLOGO", "WEBMASTEREMAIL",
      "CREDITCARDLINKURL", "ECHECKLINKURL", "DOCUMENTSLINKURL", "OTHERLINKURL", "WEBSITEPATH",
       "WEBSITEURL", "TEXTWELCOME", "THEMENAME"})
      Return [Enum].GetValues(GetType(Columns))
    End Function

    Sub New(ByVal CurrentAccount As ManagementCompanyUser)
      MyBase.New(CurrentAccount)
      m_AccountName = CurrentAccount.HoaAccount
    End Sub

    Sub New(ByRef item As mvItem)
      MyBase.New(item)
    End Sub

    Overloads Function id()
      Return Value(Columns.HOANO)
    End Function
#End Region

#Region "***** Association Lists ***********"
    Function AssociationList(Of T)(ByVal Model As MVNetBase, ByVal SearchClause As String, ByVal SortClause As String)
      Dim AssocationTarget As List(Of T)

      ' Find list of News Items  (This off the same server as the management company)
      Dim constructor = GetType(T).GetConstructor({GetType(MVNetBase)})
      Dim constructor2 = GetType(T).GetConstructor({GetType(mvItem)})
      Dim finder = constructor.Invoke({Model})
      Dim itemList = finder.Find(SearchClause, SortClause)
      AssocationTarget = New List(Of T)
      For Each item As mvItem In itemList
        AssocationTarget.Add(constructor2.Invoke({item}))
      Next

      Return AssocationTarget
    End Function

    Function Documents() As List(Of Document)
      If Not m_documentList Is Nothing Then Return m_documentList

      m_documentList = AssociationList(Of Document)(Me, String.Format("WITH HOANO = ""{0}""", id), "BY NAMEUC BY CREATEDATE BY CREATETIME")
      Return m_documentList
    End Function

    Function Categories() As List(Of Category)
      If Not m_categoryList Is Nothing Then Return m_categoryList

      m_categoryList = AssociationList(Of Category)(Me, String.Format("WITH HOANO = ""{0}""", id), "")
      Return m_categoryList
    End Function

    ' Build list of news for this hoauser
    Overrides Function NewsList()
      If Not m_NewsList Is Nothing Then Return m_NewsList

      m_NewsList = AssociationList(Of News)(Me, String.Format("WITH HOANO = ""{0}""", id), "BY CREATEDATE")
      Return m_NewsList
    End Function

    ' Build list of news for this hoauser
    Overrides Function EventsList()
      If Not m_EventsList Is Nothing Then Return m_EventsList

      m_EventsList = AssociationList(Of Events)(Me, String.Format("WITH HOANO = ""{0}""", id), "BY EVENTDATE")
      Return m_EventsList
    End Function
    ' Build list of survey questions for this hoauser
    Overrides Function SurveyList()
      If Not m_SurveyList Is Nothing Then Return m_SurveyList

      m_SurveyList = AssociationList(Of Survey)(Me, String.Format("WITH HOANO = ""{0}""", id), "BY @ID")
      Return m_SurveyList
    End Function

    Overrides Function ProviderList()
      If Not m_ProviderList Is Nothing Then Return m_ProviderList

      m_ProviderList = AssociationList(Of Provider)(Me, String.Format("WITH HOANO = ""{0}""", id), "BY @ID")
      Return m_ProviderList
    End Function
#End Region

#Region "***** Model Specific Properties ***********"
    Function Name()
      Return Value(Columns.HOANAME)
    End Function

    Function FormattedAddress()
      Return String.Format("{0} {1}", Value(Columns.HOAADD1), Value(Columns.HOACSZ))
    End Function

    ' Special case to substitute special CRLF character with normal CRLF for display
    Function WelcomeText() As String
      Return Value(Columns.TEXTWELCOME).Replace(DataBASIC.VM, DataBASIC.CRLF)
    End Function

    Function WebsitePrefix() As String
      Return Account.ManagementCompany.WebsitePath
    End Function

    Function ShowEmail() As Boolean
      Return Value(Columns.SHOWEMAIL) = "1"
    End Function

    Function ShowManagementLogo() As Boolean
      Return Value(Columns.SHOWMGMTCOLOGO) = "1"
    End Function

    Function Themes() As List(Of SelectListItem)
      Dim list As List(Of SelectListItem) = New List(Of SelectListItem)
      For Each item In {"Default", "Antiquity", "Grayscale", "Mocha", "Seafoam", "Zeitgeist"}
        Dim selected As Boolean = Value(Columns.THEMENAME) = item
        list.Add(New SelectListItem With {.Selected = selected, .Text = item, .Value = item})
      Next
      Return list
    End Function

#End Region

#Region "***** Paths and filenames ***********"
    Function AssetFolder()
      Return PhysicalAssetFolder(Account.ManagementCompany.Path & "\\" & Value(Columns.WEBSITEPATH))
    End Function

    Function AssetPath(Optional ByVal filename As String = Nothing) As String
      Dim extension = ""
      If (Not filename Is Nothing) Then extension = filename.Split(".").Last
      CreateFolder(AssetFolder)
      Return AssetFolder() & "\\logo." & extension
    End Function

    Function DocumentPath(ByVal filename)
      CreateFolder(AssetFolder)
      Return String.Format("{0}\\{1}", AssetFolder, filename)
    End Function

    Function LogoPath(Optional ByVal filename As String = Nothing) As String
      Dim extension = ""
      If (Not filename Is Nothing) Then extension = filename.Split(".").Last
      CreateFolder(AssetFolder)
      Return AssetFolder() & "\\logo." & extension
    End Function

    Function LogoUrl()
      Return AssetPath("logo")
    End Function

#End Region

  End Class
End Namespace

