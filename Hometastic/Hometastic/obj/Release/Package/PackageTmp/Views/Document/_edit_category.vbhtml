<script type="text/javascript">
  $(function () {

    $('a.edit_category').click(function () {
      var dlg = $('<div></div>').load($(this).attr("href"));
      dlg.dialog({
        autoOpen: false,
        modal: true,
        title: "@Model.action Category",
        buttons: {
          "@Model.action": function () {
            dlg.dialog("close");
            $(dlg.find('form')).submit();
            return false;
          },
          "Cancel": function () { dlg.dialog("close"); }
        }
      });
      dlg.dialog('open');
      return false;
    });
  });
</script>
