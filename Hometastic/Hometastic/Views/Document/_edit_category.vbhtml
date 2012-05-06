<script type="text/javascript">
  $(function () {
    var dlg = $('<div></div>').load('@Url.Action(Model.action, "Category")')
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

    $('a[category_id]').click(function () {
      dlg.find('input').val($(this).closest('td').find('span.category').text());
      dlg.dialog('open');
      return false;
    });
  });
</script>
