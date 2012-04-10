<!DOCTYPE html

<html>
<head>
  <title>@ViewData("Title")</title>
  <link href="@Url.Content("~/Content/home.css")" rel="stylesheet" type="text/css" />
  <link href="@Url.Content("~/Content/demo_page.css")" rel="stylesheet" type="text/css" />
  <link href="@Url.Content("~/Content/demo_table_jui.css")" rel="stylesheet" type="text/css" />
  <link href="@Url.Content("~/Content/jquery.dataTables_themeroller.css")" rel="stylesheet" type="text/css" />
  <link href="@Url.Content("~/Content/jquery-ui-1.8.18.custom.css")" rel="stylesheet" type="text/css" />
  <script src="@Url.Content("~/Scripts/jquery-1.7.1.min.js")" type="text/javascript"></script>
  <script src="@Url.Content("~/Scripts/jquery-ui-1.8.18.min.js")" type="text/javascript"></script>
  <script src="@Url.Content("~/Scripts/jquery.dataTables.js")" type="text/javascript"></script>
  <script type="text/javascript">
    $(document).ready(function () {
      $('table.dataTable').dataTable({
        "bJQueryUI": true,
        "sPaginationType": "full_numbers"

      });
    });  
  </script>
  @RenderSection("JavaScript", False)
</head>
<body>
  <div id="container">
    <div id="menu-container">
      <div id="left">
        <img src="/Images/corner.gif" class="corner" alt="" />
        <a href="/">
          <img src="/Images/logo.gif" class="logo" alt="Hometastic.com - Websites Fot Community Living" />
        </a>
      </div>
      <div id="right">
        @Html.Partial("_Menu", New With {.capitalize = True, .cssClass = "management_company"})
      </div>
      <div id="main">
        @RenderBody()
      </div>
    </div>
    <div id="footer">
      @Html.Partial("_Footer")
    </div>
  </div>
</body>
</html>
