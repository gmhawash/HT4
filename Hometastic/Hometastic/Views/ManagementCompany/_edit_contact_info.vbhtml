@ModelType Hometastic.Models.ManagementCompanyUser
<div>
  <p>
    This tools lets you enter the text that will be shown on the frontpage of your web
    site (Introduction) and on the page with your management company information (About
    Us).
  </p>
  <div class="management_company edit">
    <div class="field">
      @Html.Label("Address 1")
      @Html.TextBox("CADD1", Model.Address1)
    </div>

    <div class="field">
      @Html.Label("Address 1")
      @Html.TextBox("CADD1", Model.Address2)
    </div>

    @Code 
      Dim items = {({"City", "CCITY"}), _
                 ({"State", "CST"}), _
                 ({"Zip", "CONTACTZIPCODE"}), _
                 ({"Contact E-Mail", "CONTACTEMAIL"}), _
                 ({"Webmaster E-Mail", "WEBMASTEREMAIL"}), _
                 ({"Phone", "CONTACTPHONE"}), _
                 ({"Fax", "MGMTCOFAX"}), _
                 ({"Emergency Contact", "CONTACTNAME"}), _
                 ({"Redirect Override URL", "WEBSITEURL"})
                 }
      For Each item As String() In items
        @<div class="field">
          @Html.Label(item(0))
          @Html.TextBox(item(1), Model.Value(item(1)))
        </div>
      Next
    End Code

    <div class="field">
      @Html.Label("Path:")
      <span>@Model.WebsitePath</span>
    </div>

    <div class="field">
      @Html.Label("Theme")
      @Html.DropDownList("THEMENAME", Model.Themes)
    </div>

    <div class="field checkbox">
      @Html.CheckBox("PASSPROTECTPROPERTIES", Model.Value("PASSPROTECTPROPERTIES"))
      <span>Require user to enter property name for access</span>
    </div>

    <div class="field checkbox">
      @Html.CheckBox("SHOWEMAIL", Model.Value("SHOWEMAIL"))
      <span>Show email address of Vendor and Service Providers</span>
    </div>

    <div class="field">
      @Html.Label("Disk Quota:")
      <span>@Model.Value("DISKQUOTA") MB</span>
    </div>
  </div>
</div>
