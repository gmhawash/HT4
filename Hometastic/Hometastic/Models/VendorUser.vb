Imports BlueFinity.mvNET.CoreObjects
Namespace Models
  Public Class VendorUser
    Inherits MVNetBase

#Region "***** Table Definition ***********"
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

    Overrides Function TableColumns()
      m_TableName = "DWVENDOR"
      Return [Enum].GetValues(GetType(Columns))
    End Function

    Sub New(ByRef CurrentAccount As ManagementCompanyUser)
      MyBase.New(CurrentAccount)
      m_AccountName = CurrentAccount.HoaAccount
    End Sub

    Sub New(ByRef item As mvItem)
      MyBase.New(item)
    End Sub

    ' TODO: Why is this differnet? Can we move to base?
    Overloads Function Id()
      Return m_mvItem.ID
    End Function
#End Region

#Region "***** Model Specific Properties ***********"

    Function Name()
      Return Value(Columns.VNAME)
    End Function

    Function FormattedAddress()
      Return String.Format("{0} {1}", Value(Columns.VADD1), Value(Columns.VCSZ))
    End Function
#End Region
  End Class
End Namespace

