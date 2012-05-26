(function() {

  this.InitializeCallbacks = function() {
    return $('a.delete_item').bind('click', function(event) {
      var href;
      event.preventDefault;
      if (confirm("Are you sure you want to delete is news item? Click 'OK' to confirm, 'Cancel' otherwise.")) {
        if ((href = $(this).attr("href")) != null) {
          $('#spinner').show();
          $.post(href, function() {
            return document.location.href = '@Url.Action("Index")';
          });
        }
      }
      return false;
    });
  };

}).call(this);
