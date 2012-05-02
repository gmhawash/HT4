@ModelType Hometastic.Models.HoaUser
<div>
  <p>
    In this step you can upload an image that will be shown on the frontpage of your
    HOA web site. The image should be in GIF or JPEG format and should not be larger
    than 300x200 pixels in size.
  </p>
  <div id="logo-container">
    @Html.Partial("_edit_images", New With {.purpose = "logo", .title = "Upload Logo", .image_path = Model.LogoPath}) 
  </div>

<br />
    <div class="field">
      @Html.Label("Theme")
      @Html.DropDownList("THEMENAME", Model.Themes)
    </div>
</div>
