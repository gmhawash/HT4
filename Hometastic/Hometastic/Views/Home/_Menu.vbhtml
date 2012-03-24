<div id="menu">
<ul>
  @For Each item As String() In ViewBag.Menu
    Dim klass = item(0).ToLower() + " menu"
    @<li>
      <a href="@item(1)" class="menu @item(0).ToLower().Replace(" "c, "_"c)">@item(0).ToUpper()</a>
    </li>
  Next
</ul>
</div>