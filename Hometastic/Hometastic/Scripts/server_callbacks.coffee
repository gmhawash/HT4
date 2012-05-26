@InitializeCallbacks = () -> 
  $('a.delete_item').bind 'click', (event) ->
    event.preventDefault
    if (confirm("Are you sure you want to delete is news item? Click 'OK' to confirm, 'Cancel' otherwise."))
      if (href = $(@).attr("href"))?
        $('#spinner').show()
        $.post href, -> 
          document.location.href = '@Url.Action("Index")'

    return false