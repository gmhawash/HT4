@ModelType Hometastic.Models.Document

@Html.Partial("_edit_category", New With {.action = "Create"})

<h2>Manage HOA Documents</h2>
<p>
To post an announcement or news article on your site please enter its title, provide
  a brief summary in the "Headline" field, and type in the announcement in the "Article"
  field. When you are done click on the [Save] button.
</p>

<div id="main-body">
  @Using Html.BeginForm()
    @<div class="news edit">
      <div class="field">
        @Html.Label("Title")
        @Html.TextBox("NAME", Model.Value("NAME"))
      </div>
      <div class="field">
        @Html.Label("Category")
        @Html.DropDownList("CATEGORYID", Model.Categories)
        <a class="float_right button" href="#" category_id="">New Category</a>
      </div>
      <div class="field">
        @Html.Label("Password Protection")
        @Html.DropDownList("PASSPROTECT", Model.AuthorizationLevels)
      </div> 
      <div class="field">
        @Html.Label("Description")
        @Html.TextArea("DESCRIPTION", Model.Value("DESCRIPTION"))
      </div>
    </div>

    @<div id="document-container">
      @Html.Partial("_upload_document",
                       New With {.purpose = "document",
                                 .title = "Add Document"
                                })
    </div>
    @<div id="action">
      <input type="submit" value="Add item" />
    </div>
  End Using
</div>