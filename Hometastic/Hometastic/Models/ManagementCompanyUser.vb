Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class ManagementCompanyUser
    Inherits MVNetBase

    Dim m_hoaUsers As List(Of HoaUser) = Nothing

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

    Sub New(ByVal id As String)
      m_TableName = "DWMASTER"
      m_AccountName = "AsiAr"
      ParseColumns([Enum].GetValues(GetType(Columns)))
      Read(id)
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

  End Class
End Namespace

