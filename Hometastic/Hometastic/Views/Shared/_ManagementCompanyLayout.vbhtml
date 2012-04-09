<!DOCTYPE html>
<html>
<head>
  <title>@ViewData("Title")</title>
  <link href="@Url.Content("~/Content/home.css")" rel="stylesheet" type="text/css" />
  <script src="@Url.Content("~/Scripts/jquery-1.5.1.min.js")" type="text/javascript"></script>
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
<!DOCTYPE html>
<html>
