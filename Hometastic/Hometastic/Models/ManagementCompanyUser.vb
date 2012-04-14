Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class ManagementCompanyUser
    Inherits MVNetBase

    Dim m_hoaUsers As List(Of HoaUser) = Nothing
    Dim m_vendorUsers As List(Of VendorUser) = Nothing

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
      LASTLOGINDATETIME
      MVNETLOGIN
      WEBSITECREATEDATE
      THEMENAME
    End Enum

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

    Overloads Sub Write(ByVal record As FormCollection)
      record("TEXTINTRO") = record("TEXTINTRO").Replace(DataBASIC.CRLF, DataBASIC.VM)
      record("TEXTABOUT") = record("TEXTABOUT").Replace(DataBASIC.CRLF, DataBASIC.VM)
      MyBase.Write(record)
    End Sub

    Function Introduction() As String
      Return Value(Columns.TEXTINTRO).Replace(DataBASIC.VM, DataBASIC.CRLF)
    End Function

    Function AboutUs() As String
      Return Value(Columns.TEXTABOUT).Replace(DataBASIC.VM, DataBASIC.CRLF)
    End Function

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

    Function Address1()
      Return Value(Columns.CONTACTADD1)
    End Function

    Function Address2()
      Return Value(Columns.CONTACTADD2)
    End Function

    Function WebsitePath()
      Dim url = HttpContext.Current.Request.Url
      Return String.Format("{0}{1}{2}/sites/{3}", url.Scheme, url.SchemeDelimiter, url.Host, Value(Columns.WEBSITEPATH))
    End Function

    Function ShowEmail() As Boolean
      Return Value(Columns.SHOWEMAIL) = "1"
    End Function

    Function PasswordProtect() As Boolean
      Return Value(Columns.PASSPROTECTPROPERTIES) = "1"
    End Function

    Function Themes() As List(Of SelectListItem)
      Dim list As List(Of SelectListItem) = New List(Of SelectListItem)
      For Each item In {"Default", "Antiquity", "Grayscale", "Mocha", "Seafoam", "Zeitgeist"}
        Dim selected As Boolean = Value(Columns.THEMENAME) = item
        list.Add(New SelectListItem With {.Selected = selected, .Text = item, .Value = item})
      Next
      Return list
    End Function
  End Class
End Namespace

