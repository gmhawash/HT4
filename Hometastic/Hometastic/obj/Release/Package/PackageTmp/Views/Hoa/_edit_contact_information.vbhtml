@ModelType Hometastic.Models.HoaUser
<div>
  <p>
    In this step you can enter contact information that will be displayed on the contact
    page of your web site (Contact Us) allowing site visitors to get in touch with your
    HOA. You must also choose a path for your HOA web site - that path will be part
    of the URL used to locate your site on the Internet.
  </p>
  <div class="management_company edit">
    @Code 
      Dim items = {({"Phone Number", "CONTACTPHONE"}), _
                 ({"Fax Number", "CONTACTFAX"}), _
                 ({"Contact Email", "CONTACTEMAIL"}), _
                 ({"Webmaster E-Mail", "WEBMASTEREMAIL"}), _
                 ({"Address", "CADD1"}), _
                 ({" ", "CADD2"}), _
                 ({"City", "CCITY"}), _
                 ({"State", "CST"}), _
                 ({"Zip", "CONTACTZIPCODE"})
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
