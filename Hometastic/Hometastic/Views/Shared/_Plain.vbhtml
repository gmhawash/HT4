<!DOCTYPE html>
<html>
<head>
  <title>@ViewData("Title")</title>
  <link href="@Url.Content("~/Content/home.css")" rel="stylesheet" type="text/css" />
  <script src="@Url.Content("~/Scripts/jquery-1.5.1.min.js")" type="text/javascript"></script>
  <script src="@Url.Content("~/Scripts/jquery.unobtrusive-ajax.min.js")" type="text/javascript"></script>

  @RenderSection("JavaScript", false)
</head>
<body>
   @RenderBody()
</body>
</html>
