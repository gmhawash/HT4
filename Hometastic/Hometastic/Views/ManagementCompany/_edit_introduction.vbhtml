@ModelType Hometastic.Models.ManagementCompanyUser
<div>
  <p>
    This tools lets you enter the text that will be shown on the frontpage of your web
    site (Introduction) and on the page with your management company information (About
    Us).
  </p>
  @Code
    @<div class="management_company edit">
      <div class="field">
        @Html.Label("Introduction")
        @Html.TextArea("TEXTINTRO", Model.Value("TEXTINTRO"))
      </div>
      <div class="field">
        @Html.Label("About Us")
        @Html.TextArea("TEXTIABOUT", Model.Value("TEXTABOUT"))
      </div>
    </div>
  End Code
</div>
