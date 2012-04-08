Namespace Models
  Public Class ManagementCompanyUser
    Inherits MVNetBase

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
    End Enum

    Sub New()
      m_TableName = "DWMASTER"
      m_AccountName = "AsiAr"
      ParseColumns([Enum].GetValues(GetType(Columns)))
    End Sub
  End Class
End Namespace

