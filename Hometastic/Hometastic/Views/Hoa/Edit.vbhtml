@ModelType Hometastic.Models.HoaUser
@Code
  ViewData("Title") = "Manage Company Site"
  Layout = "~/Views/Shared/_ManagementCompanyLayout.vbhtml"
End Code

@Section JavaScript
<script type="text/javascript">
  $(function () {
    var icons = {
      header: "ui-icon-circle-arrow-e",
      headerSelected: "ui-icon-circle-arrow-s"
    };
    $("#accordion").accordion({
      icons: icons,
      active: 0,
      autoHeight: false
    });
  });
</script>
End Section

<div id="main-body">
  <p class="don-t-delete-me"></p>
  @Using Html.BeginForm()
      @<div id="accordion">
        <h3><a href="#">Contact Information</a></h3>
        @Html.Partial("_edit_contact_information")
        <h3><a href="#">Website Configuration</a></h3>
        @Html.Partial("_edit_website_configuration")
        <h3><a href="#">Theme and Logo</a></h3>
        @Html.Partial("_edit_front_image_theme")
      </div>
      @<div></div>
      @<input type="submit" value="Update" />
  End Using
</div>
