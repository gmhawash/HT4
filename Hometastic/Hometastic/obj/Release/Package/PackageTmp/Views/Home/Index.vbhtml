@Section JavaScript
<script type="text/javascript">
  $(function () {
    $('#userType_hoa').click(function () { $(".input.clientNumber").show(); });
    $('#userType_mgmtCompany').click(function () { $(".input.clientNumber").hide(); });
  });
</script>
End Section

@Html.Partial("_Login")
@Html.Partial("_Body")
@Html.Partial("_Right")