<h2>Manage News / Announcements</h2>
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
        @Html.TextBox("TITLE", Model.Value("TITLE"))
      </div>
      <div class="field">
        @Html.Label("Headline")
        @Html.TextArea("HEADLINE", Model.Value("HEADLINE"))
      </div>
      <div class="field">
        @Html.Label("Article")
        @Html.TextArea("BODY", Model.Body)
      </div>
    </div>
    @<div id="action">
      <input type="submit" value="Add item" />
    </div>
  End Using
</div>