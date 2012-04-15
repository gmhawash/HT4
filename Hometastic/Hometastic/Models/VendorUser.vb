Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class VendorUser
    Inherits MVNetBase

    Public Enum Columns
      SERVICESCONTACTINFO
      SERVICESDESC
      SERVICESTITLE
      DPASSWORD
      VNAME
      LASTLOGINDATE
      VADD1
      VADD2
      VCSZ
      VEMAIL
      VPHONE
      VFAX
    End Enum

    Sub New(ByVal accountName As String)
      m_TableName = "DWVENDOR"
      m_AccountName = accountName
      ParseColumns([Enum].GetValues(GetType(Columns)))
    End Sub

    Sub New(ByVal item As mvItem)
      m_mvItem = item
      ParseColumns([Enum].GetValues(GetType(Columns)))
    End Sub

    Function name()
      Return Value(Columns.VNAME)
    End Function

    Function formattedAddress()
      Return String.Format("{0} {1}", Value(Columns.VADD1), Value(Columns.VCSZ))
    End Function

    Overloads Function id()
      Return m_mvItem.ID
    End Function
  End Class
End Namespace

