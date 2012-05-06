<script type="text/javascript">
  $(function () {
    var uploader = new qq.FileUploader({
      // pass the dom node (ex. $(selector)[0] for jQuery users)
      element: document.getElementById('@Model.purpose'),
      // path to server-side upload script
      action: '@Url.Action("Upload", "Document")',
      debug: true,
      multiple: false,
      params: {
        purpose: '@Model.purpose'
      },
      onComplete: function (id, filename, responseJSON) {
        $('span.qq-upload-failed-text').hide();
        $('#TempFilename').val(responseJSON.tempFilename);
        $('#Filename').val(responseJSON.filename);
        return true;
      },
      template: $('#@Model.purpose-Template').html(),
      onSubmit: function (id, fileName) { $('.qq-upload-list').html(""); }
    });
  });
</script>

 <script type='text/template' id="@Model.purpose-Template">
  <div class="file-uploader">
    <div class="qq-upload-drop-area"></div>
    <div class="qq-upload-list"></div>
    <div class="qq-upload-button file-add linkish button">@Model.title</div>
  </div>
</script>

@Html.Hidden("TempFilename")
@Html.Hidden("Filename")

<div id="@Model.purpose">       
    <noscript>
        <p>Please enable JavaScript to use file uploader.</p>
        <!-- or put a simple form for upload here -->
    </noscript>         
</div>