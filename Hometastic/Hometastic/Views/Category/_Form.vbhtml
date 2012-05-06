@ModelType Hometastic.Models.Category

<div id="main-body">
  <p>
  NOTE: Changing the category for this document will apply to all documents with the same category.
  </p>
  @Using Ajax.BeginForm(New AjaxOptions With {.HttpMethod = "POST"})
      @<div class="field">
        @Html.Label("Category")
        @Html.TextBox("DESCRIPTION", Model.Value("DESCRIPTION"))
      </div>
  End Using
</div>