<div id="menu-container">
  <div id="left">
    <img src="/Images/corner.gif" class="corner" alt="" />
    <a href="/">
      <img src="/Images/logo.gif" class="logo" alt="Hometastic.com - Websites Fot Community Living" />
    </a>
    <div id='wave'>
      <img src="/Images/waves.gif" class="logo" alt="Hometastic.com - Websites Fot Community Living" />
    </div>
    <div id="message" class="small">
      <p>
        Welcome to the new way management companies are providing a valuable service to
        their homeowners associations.
      </p>
      <p>
        Explore our site further and we are sure you'll find enough reasons to
        @Html.ActionLink("give us a call", "Contact", "Home"). We would love to add you
        to our list of satisfied clients.  @Html.ActionLink("Read more»", "About", "Home")
      </p>
    </div>
  </div>
  <div id="right">
    <ul id="menu">
      @For Each item As String() In ViewBag.Menu
        Dim klass = item(0).ToLower() + " menu"
        @<li>
          @Html.ActionLink(item(0), item(1), item(2), vbNull, New With {.class = klass})
        </li>
      Next
    </ul>
  </div>
</div>
