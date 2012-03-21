<div id="menu-container">
  <div id="left">
    <img src="/Images/corner.gif" class="corner" alt=""/>
    <a href="/">
      <img src="/Images/logo.gif" class="logo" alt="Hometastic.com - Websites Fot Community Living" />
    </a>
  </div>
  <div id="right">
    <ul id="menu">
      @For Each item As String() In ViewBag.Menu
        Dim klass = item(0).ToLower()
        @<li>
          @Html.ActionLink(item(0), item(1), item(2), vbNull, New With {.class = klass})
        </li>
      Next
    </ul>
  </div>
</div>

