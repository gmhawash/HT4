<!DOCTYPE html>
<html>
<head>
  <title>@ViewData("Title")</title>
  <link href="@Url.Content("~/Content/home.css")" rel="stylesheet" type="text/css" />
  <script src="@Url.Content("~/Scripts/jquery-1.5.1.min.js")" type="text/javascript"></script>
  @RenderSection("JavaScript", false)
</head>
<body>
  <div id="container">
    <div id="menu-container">
      <div id="left">
      </div>
      <div id="right">

        <div id="main">
          @RenderBody()
        </div>
      </div>
    </div>
    <div id="footer">
    </div>
  </div>
</body>
</html>
