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

    Sub New()
      m_TableName = "DWMASTER"
      m_AccountName = "AsiDbDemo"
      ParseColumns([Enum].GetValues(GetType(Columns)))
    End Sub
  End Class
End Namespace

