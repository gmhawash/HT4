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
      active: 1,
      autoHeight: false
    });

    // This fixes an issue with accordion and checkboxes.
    // http://stackoverflow.com/questions/7426425/jqueryui-accordion-question
    $("#accordion input[type='checkbox']").click(function (evt) {
      evt.stopPropagation();
    }); 

    $('#accordion').click(function () {
      $(this).next().toggle('slow');
      return false;
    }).next().hide();

    setTimeout(function () { $('#accordion a').first().click(); }, 1000);
  });
</script>
End Section

<div id="main-body">
  <p>
  </p>
  @Using Html.BeginForm()
    @<div id="accordion"> 
        <h3><a href="#">Website Configuration</a></h3>
        @Html.Partial("_edit_website_configuration")
        <h3><a href="#">Front Image and Theme</a></h3>
        @Html.Partial("_edit_front_image_theme") 
    </div>
    @<div></div>
    @<input type="submit" value="Update" />
  End Using
</div>
