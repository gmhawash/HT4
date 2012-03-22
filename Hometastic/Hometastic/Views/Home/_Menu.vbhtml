<ul id="menu">
  @For Each item As String() In ViewBag.Menu
    Dim klass = item(0).ToLower() + " menu"
    @<li>
      @Html.ActionLink(item(0), item(1), item(2), vbNull, New With {.class = klass})
    </li>
  Next
</ul>
