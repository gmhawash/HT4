Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class HoaUser
    Inherits MVNetBase

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
    End Enum

    Sub New(ByVal accountName As String)
      m_TableName = "DWMASTER"
      m_AccountName = accountName
      ParseColumns([Enum].GetValues(GetType(Columns)))
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
      Return Account.ManagementCompany.Themes
    End Function

    Function LogoPath()
      ' Return MyConfiguration.AssetUrl("logo", Value(Columns.WEBSITEPATH), GetFileName(Id() & ".*"))
      Return "somepath"
    End Function
  End Class
End Namespace

