@ModelType Hometastic.Models.Provider
<h2>
  Manage Provider</h2>
<div id="main-body" class="edit">
    @Using Html.BeginForm()
      Dim items = {({"Name", "NAME"}),
                 ({"Service Title", "TITLE"})}

      @Html.Partial("_text_fields", New With {.items = items, .source = Model}) 

        @<div class="field">
          @Html.Label("Service Description")
          @Html.TextArea("DESC", Model.Desc)
        </div>
      items = {({"Person to Contact", "CONTACTINFO"}),
                 ({"Address 1", "ADDR1"}),
                 ({"Address 2", "ADDR2"}),
                 ({"City, State Zip", "CSZ"}),
                 ({"Website URL", "WEBSITEURL"}),
                 ({"Phone", "PHONENO"}),
                 ({"Cell Phone", "CELLNO"}),
                 ({"Email", "EMAIL"})
               }

      @Html.Partial("_text_fields", New With {.items = items, .source = Model}) 

      @<div class="clear">
        <input type="submit" value="Update" />
      </div>
    End Using
</div>
