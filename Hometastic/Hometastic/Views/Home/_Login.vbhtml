﻿
<div id="login" class="small">
@Using Html.BeginForm()
  @<div>
    <label class="bold">
      Login As:</label>
    <ul>
      <li>@Html.RadioButton("userType", "ManagementCompany", True, New With {.id = "userType_mgmtCompany"})<label for="userType_mgmtCompany">Managment
        Company</label></li>
      <li>@Html.RadioButton("userType", "Hoa", false, New With {.id = "userType_hoa"})<label for="userType_hoa">HOA</label></li>
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