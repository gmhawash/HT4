

<div class="copyright">
  © 2005-2012 , All rights reserved<a href="http://www.advantos.net">Advantos Systems,
    Inc.</a> 
    <a href="/Home/TOS">Terms of Service</a> and <a href="/Home/Privacy">Privacy Statement</a>
</div>
<div class="menu">
  <ul>
    @For Each item As String() In ViewBag.Menu
      Dim klass = item(0).ToLower() + " footer"
      @<li>
        <a href="@item(1)" class="menu @item(0).ToLower().Replace(" "c, "_"c)">
            @item(0)
        </a>
      </li>
    Next
  </ul>
</div>
