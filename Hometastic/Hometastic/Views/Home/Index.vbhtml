@Section JavaScript
<script type="text/javascript">
  $(function () {
    $('#userType_hoa').click(function () { $(".input.clientNumber").show(); });
    $('#userType_mgmtCompany').click(function () { $(".input.clientNumber").hide(); });
  });
</script>
End Section


<div id="login" class="small">
@Using Html.BeginForm("LogOn", "Home")
  @<div>
    <label class="bold">
      Login As:</label>
    <ul>
      <li>@Html.RadioButton("userType", "mgmtCompany", True, New With {.id = "userType_mgmtCompany"})<label for="userType_mgmtCompany">Managment
        Company</label></li>
      <li>@Html.RadioButton("userType", "hoa", false, New With {.id = "userType_hoa"})<label for="userType_hoa">HOA</label></li>
    </ul>
    <div class="clear spacer">
    </div>
    <div class="clear spacer">
      @For Each Item As String() In {({"Mgmt. Company ID.", "mgmtCoId"}), ({"Clinet#", "clientNumber"}), ({"Password", "password"})}
        @<div class="input @Item(1)">
          <label>
            @Item(0)</label>
          @Html.TextBox(Item(1))
        </div>
      Next
    </div>
    <div id="action">
      <input type="submit" value="Log On" />
    </div>
  </div>
End Using
</div>
