Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class HoaUser
    Inherits MVNetBase
    Dim m_documentList As List(Of Document) = Nothing
    Dim m_categoryList As List(Of Category) = Nothing
    Dim m_NewsList As List(Of News) = Nothing

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

    Sub New(ByVal accountName As String)
      m_TableName = "DWMASTER"
      m_AccountName = accountName
      ParseColumns([Enum].GetValues(GetType(Columns)))

      m_WriteableColumnList = New List(Of String)(New String() _
      {"DISKQUOTA", "CADD1", "CADD2", "CCITY", "CST", "CONTACTPHONE", "CONTACTFAX",
      "CONTACTZIPCODE", "CONTACTEMAIL", "SHOWEMAIL", "SHOWMGMTCOLOGO", "WEBMASTEREMAIL",
      "CREDITCARDLINKURL", "ECHECKLINKURL", "DOCUMENTSLINKURL", "OTHERLINKURL", "WEBSITEPATH",
       "WEBSITEURL", "TEXTWELCOME", "THEMENAME"})
    End Sub

    Sub New(ByVal item As mvItem)
      m_mvItem = item
      ParseColumns([Enum].GetValues(GetType(Columns)))
    End Sub

    Function name()
      Return Value(Columns.HOANAME)
    End Function

    Function formattedAddress()
      Return String.Format("{0} {1}", Value(Columns.HOAADD1), Value(Columns.HOACSZ))
    End Function

    Overloads Function id()
      Return Value(Columns.HOANO)
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

    Function Documents() As List(Of Document)
      If Not m_documentList Is Nothing Then Return m_documentList

      ' Find list of News Items  (This off the same server as the management company)
      Dim finder = New Document(Me)
      Dim itemList = finder.Find(String.Format("WITH HOANO = ""{0}""", id), "BY NAMEUC BY CREATEDATE BY CREATETIME")
      m_documentList = New List(Of Document)
      For Each item As mvItem In itemList
        m_documentList.Add(New Document(item))
      Next

      Return m_documentList
    End Function

    Function Categories() As List(Of Category)
      If Not m_categoryList Is Nothing Then Return m_categoryList

      ' Find list of News Items  (This off the same server as the management company)
      Dim finder = New Category(Me)
      Dim itemList = finder.Find(String.Format("WITH HOANO = ""{0}""", id), "")
      m_categoryList = New List(Of Category)
      For Each item As mvItem In itemList
        m_categoryList.Add(New Category(item))
      Next

      Return m_categoryList
    End Function

    ' Build list of news for this management comapany
    Overrides Function NewsList()
      If Not m_NewsList Is Nothing Then Return m_NewsList

      ' Find list of News Items  (This off the same server as the management company)
      Dim finder = New News(Me)
      Dim itemList = finder.Find(String.Format("WITH HOANO = ""{0}""", id), "BY CREATEDATE")
      m_NewsList = New List(Of News)
      For Each item As mvItem In itemList
        m_NewsList.Add(New News(item))
      Next

      Return m_NewsList
    End Function

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

  End Class
End Namespace

