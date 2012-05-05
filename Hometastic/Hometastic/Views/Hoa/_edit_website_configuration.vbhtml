@ModelType Hometastic.Models.HoaUser
<div>
  <p>
    In this step you can enter contact information that will be displayed on the contact
    page of your web site (Contact Us) allowing site visitors to get in touch with your
    HOA. You must also choose a path for your HOA web site - that path will be part
    of the URL used to locate your site on the Internet.
  </p>
  <div class="management_company edit">
    <div class="field">
      @Html.Label("Introduction")
      @Html.TextArea("TEXTWELCOME", Model.WelcomeText)
    </div>

    <div class="field">
      @Html.Label(Model.WebsitePrefix)
      @Html.TextBox("WEBSITEPATH", Model.Value("WEBSITEPATH"))
    </div>

    <div class="field">
      @Html.Label("Override URL")
      @Html.TextBox("WEBSITEURL", Model.Value("WEBSITEURL"))
    </div>
    
    <div class="field checkbox">
      @Html.CheckBox("SHOWMGMTCOLOGO", Model.ShowManagementLogo)
      <span>Show management company logo in the header</span>
    </div>

    <div class="field checkbox">
      @Html.CheckBox("SHOWEMAIL", Model.ShowEmail)
      <span>Show email address of Service Providers on public site</span>
    </div>

    @Code 
      Dim items = {({"E-Check URL", "ECHECKLINKURL"}), _
                 ({"Credit Card URL", "CREDITCARDLINKURL"}), _
                 ({"Documents URL", "DOCUMENTSLINKURL"}), _
                 ({"Other URL", "OTHERLINKURL"}), _
                 ({"Disk Quota (MB)", "DISKQUOTA"})
                 }
      For Each item As String() In items
        @<div class="field">
          @Html.Label(item(0))
          @Html.TextBox(item(1), Model.Value(item(1)))
        </div>
      Next
    End Code
  </div>
</div>
