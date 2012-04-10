@ModelType Hometastic.Models.ManagementCompanyUser
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
      icons: icons
    });

    $('#accordion').click(function () {
      $(this).next().toggle('slow');
      return false;
    }).next().hide();
  });
</script>
End Section

<div id="main-body">
  <p>
  </p>
  <div id="accordion">
    <h3><a href="#">Introduction & About Us</a></h3>
    @Html.Partial("_edit_introduction")
    <h3> <a href="#">Contact Information</a></h3>
    @Html.Partial("_edit_contact_info")
  </div>
</div>
