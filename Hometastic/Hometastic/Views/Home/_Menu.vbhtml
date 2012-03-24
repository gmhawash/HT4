<div class="menu">
  <ul>
    @For Each item As String() In ViewBag.Menu
      Dim klass = item(0).ToLower().Replace(" "c, "_"c) + " footer"
      If (item(1) = Request.Path) Then klass += " active"
      Dim text = If(Model.capitalize = True, item(0).ToUpper(), item(0))
         
      @<li>
        <a href="@item(1)" class="menu @klass"> @text </a>
      </li>
    Next
  </ul>
</div>