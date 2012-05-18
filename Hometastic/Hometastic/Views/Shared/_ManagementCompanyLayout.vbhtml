<!DOCTYPE html

<html>
<head>
  <title>@ViewData("Title")</title>
  <link href="@Url.Content("~/Content/demo_page.css")" rel="stylesheet" type="text/css" />
  <link href="@Url.Content("~/Content/jquery.dataTables_themeroller.css")" rel="stylesheet" type="text/css" />
  <link href="@Url.Content("~/Content/jquery-ui-1.8.18.custom.css")" rel="stylesheet" type="text/css" />
  <link href="@Url.Content("~/Content/fileuploader.css")" rel="stylesheet" type="text/css" />
  <link href="@Url.Content("~/Content/Survey.css")" rel="stylesheet" type="text/css" />
  <link href="@Url.Content("~/Content/ManagementCompany.css")" rel="stylesheet" type="text/css" />

  <script src="@Url.Content("~/Scripts/jquery-1.7.1.min.js")" type="text/javascript"></script>
  <script src="@Url.Content("~/Scripts/jquery-ui-1.8.18.min.js")" type="text/javascript"></script>
  <script src="@Url.Content("~/Scripts/jquery.dataTables.js")" type="text/javascript"></script>
  <script src="@Url.Content("~/Scripts/fileuploader.js")" type="text/javascript"></script>
  <script src="@Url.Content("~/Scripts/mustache.js")" type="text/javascript"></script>

  <script type="text/javascript">
    $(document).ready(function () {
      $('table.dataTable').dataTable({
        "bJQueryUI": true,
        "sPaginationType": "full_numbers",
        "bSort": false
      });
      LinkToButton();
    });

   function LinkToButton() {
      $("input:submit, div.button, a.button, button").button();
    }
    
  </script>
  @RenderSection("JavaScript", False)
</head>
<body>
  <div id="container">
    @Html.Flash()
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
  <div id="spinner" class="hidden">
    <img src="/images/spinner.gif" />
  </div>
</body>
</html>
