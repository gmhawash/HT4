Imports BlueFinity.mvNET.CoreObjects
Imports System.IO
Imports System.IO.Path

Namespace Models
  Public Class ManagementCompanyUser
    Inherits MVNetBase

    Dim m_hoaUsers As List(Of HoaUser) = Nothing
    Dim m_vendorUsers As List(Of VendorUser) = Nothing
    Dim m_NewsList As List(Of News) = Nothing

    Public Enum Columns
      DISKQUOTA
      DBMSACCOUNT
      WEBMASTERNAME
      MGMTCONO
      MGMTCONAME
      MGMTCODPASSWORD
      MGMTCOPHONE
      SHOWSPECIALSERVICESLINK
      WEBSITEPATH
      WEBSITEURL
      SHOWEMAIL
      CONTACTNAME
      CONTACTADD1
      CONTACTADD2
      CADD1
      CADD2
      CONTACTCSZ
      TEXTINTRO
      TEXTABOUT
      CCITY
      CST
      CONTACTZIPCODE
      CONTACTPHONE
      CONTACTEMAIL
      PASSPROTECTPROPERTIES
      MGMTCOADD1
      MGMTCOADD2
      MGMTCOCSZ
      MGMTCOFAX
      MGMTCOEMAIL
      WEBMASTEREMAIL
      MVNETLOGIN
      THEMENAME
    End Enum

    ' Setup Management Company Database table name and account
    ' Initialize list of writable fields
    '
    Sub New(ByVal id As String)
      m_TableName = "DWMASTER"
      m_AccountName = "AsiAr"
      ParseColumns([Enum].GetValues(GetType(Columns)))
      Read(id)

      m_WriteableColumnList = New List(Of String)(New String() _
        {"TEXTINTRO", "TEXTINTRO", "CCITY", "CST", "CONTACTZIPCODE", _
         "CONTACTEMAIL", "WEBMASTEREMAIL", "CONTACTPHONE", _
         "MGMTCOFAX", "CONTACTNAME", "WEBSITEURL", "CADD1", _
         "CADD1", "THEMENAME", "SHOWEMAIL", "PASSPROTECTPROPERTIES"})
    End Sub

    ' Build list of HOA for this management company
    Function HoaList()
      If Not m_hoaUsers Is Nothing Then Return m_hoaUsers

      ' Find list of HOA Users
      Dim finder = New HoaUser(Value(ManagementCompanyUser.Columns.MVNETLOGIN))
      Dim itemList = finder.Find("WITH HOADPASSWORD # "" AND WITH HOANAME # """, "")
      m_hoaUsers = New List(Of HoaUser)
      For Each item As mvItem In itemList
        m_hoaUsers.Add(New HoaUser(item))
      Next

      Return m_hoaUsers
    End Function

    ' Build list of vendors for this managmeent company
    Function VendorList()
      If Not m_vendorUsers Is Nothing Then Return m_vendorUsers

      ' Find list of HOA Users
      Dim finder = New VendorUser(Value(ManagementCompanyUser.Columns.MVNETLOGIN))
      Dim itemList = finder.Find("", "BY VNAME")
      m_vendorUsers = New List(Of VendorUser)
      For Each item As mvItem In itemList
        m_vendorUsers.Add(New VendorUser(item))
      Next

      Return m_vendorUsers
    End Function

    ' Build list of news for this management comapany
    Function NewsList()
      If Not m_NewsList Is Nothing Then Return m_NewsList

      ' Find list of News Items  (This off the same server as the management company)
      Dim finder = New News(m_AccountName)
      Dim itemList = finder.Find(String.Format("WITH MGMTCONO = ""{0}""", Id()), "BY CREATEDATE")
      m_NewsList = New List(Of News)
      For Each item As mvItem In itemList
        m_NewsList.Add(New News(item))
      Next

      Return m_NewsList
    End Function

    ' Override Write to substitute special CRLF characters on save.
    Overloads Sub Write(ByVal record As FormCollection)
      record("TEXTINTRO") = record("TEXTINTRO").Replace(DataBASIC.CRLF, DataBASIC.VM)
      record("TEXTABOUT") = record("TEXTABOUT").Replace(DataBASIC.CRLF, DataBASIC.VM)
      MyBase.Write(record)
    End Sub

    ' Special case to substitute special CRLF character with normal CRLF for display
    Function Introduction() As String
      Return Value(Columns.TEXTINTRO).Replace(DataBASIC.VM, DataBASIC.CRLF)
    End Function

    Function AboutUs() As String
      Return Value(Columns.TEXTABOUT).Replace(DataBASIC.VM, DataBASIC.CRLF)
    End Function

    ' Contact addresses are read and written to differnet columns in mv.net
    Function Address1()
      Return Value(Columns.CONTACTADD1)
    End Function

    Function Address2()
      Return Value(Columns.CONTACTADD2)
    End Function


    ' Build public website path to manamgent company.
    ' TODO: Replace with Html.ActionLink
    Function WebsitePath()
      Dim url = HttpContext.Current.Request.Url
      Return String.Format("{0}{1}{2}/sites/{3}", url.Scheme, Uri.SchemeDelimiter, url.Host, Value(Columns.WEBSITEPATH))
    End Function

    ' Boolean values of "1" and "0"
    Function ShowEmail() As Boolean
      Return Value(Columns.SHOWEMAIL) = "1"
    End Function

    Function PasswordProtect() As Boolean
      Return Value(Columns.PASSPROTECTPROPERTIES) = "1"
    End Function

    ' List of supported themes.
    Function Themes() As List(Of SelectListItem)
      Dim list As List(Of SelectListItem) = New List(Of SelectListItem)
      For Each item In {"Default", "Antiquity", "Grayscale", "Mocha", "Seafoam", "Zeitgeist"}
        Dim selected As Boolean = Value(Columns.THEMENAME) = item
        list.Add(New SelectListItem With {.Selected = selected, .Text = item, .Value = item})
      Next
      Return list
    End Function

    Function GetFileName(ByVal filePattern As String)
      Dim path = MyConfiguration.PhysicalAssetFolder("logo", Value("WEBSITEPATH"))
      Dim dirInfo As System.IO.DirectoryInfo = New DirectoryInfo(path)

      Dim files() = dirInfo.GetFiles(filePattern)
      Dim filename = Nothing
      If files.Length > 0 Then
        Dim x As System.IO.FileInfo = files(0)
        filename = x.Name
      End If

      Return filename
    End Function

    Function LogoPath()
      Return MyConfiguration.AssetUrl("logo", Value(Columns.WEBSITEPATH), GetFileName(Id() & ".*"))
    End Function

    Function FrontPagePath()
      Return MyConfiguration.AssetUrl("front-image", Value(Columns.WEBSITEPATH), GetFileName(Id() & "_front_image.*"))
    End Function
  End Class
End Namespace

