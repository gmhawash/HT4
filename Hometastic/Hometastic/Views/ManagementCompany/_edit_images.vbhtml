﻿<script type="text/javascript">
  $(function () {
    var uploader = new qq.FileUploader({
      // pass the dom node (ex. $(selector)[0] for jQuery users)
      element: document.getElementById('@Model.purpose'),
      // path to server-side upload script
      action: '/ManagementCompany/Upload',
      debug: true,
      params: {
        purpose: '@Model.purpose'
      },
      onComplete: function (id, filename, responseJSON) {
        $('span.qq-upload-failed-text').hide();
        return true;
      }
    });
  });

</script>

<div id="@Model.purpose">       
    <noscript>          
        <p>Please enable JavaScript to use file uploader.</p>
        <!-- or put a simple form for upload here -->
    </noscript>         
</div>