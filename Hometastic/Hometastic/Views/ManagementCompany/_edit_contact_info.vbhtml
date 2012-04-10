@ModelType Hometastic.Models.ManagementCompanyUser
<div>
  <p>
    This tools lets you enter the text that will be shown on the frontpage of your web
    site (Introduction) and on the page with your management company information (About
    Us).
  </p>
  <div class="management_company edit">
  @Using Html.BeginForm()
    Dim items = {({"Address 1", "CONTACTADDR1"}), _
                 ({"Address 2", "CONTACTADDR2"}), _
                 ({"City", "CCITY"}), _
                 ({"State", "CST"}), _
                 ({"Zip", "CONTACTZIPCODE"}), _
                 ({"Contact E-Mail", "CONTACTEMAIL"}), _
                 ({"Webmaster E-Mail", "WEBMASTEREMAIL"}), _
                 ({"Phone", "CONTACTPHONE"}), _
                 ({"Fax", "MGMTCOFAX"})
                 }
      For Each item As String() In items
        @<div class="field">
          @Html.Label(item(0))
          @Html.TextBox(item(1), Model.Value(item(1)))
        </div>
      Next
  End Using
    </div>
</div>
