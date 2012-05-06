@ModelType Hometastic.Models.Document
@Code
  ViewData("Title") = "Index"
  Layout = "~/Views/Shared/_ManagementCompanyLayout.vbhtml"
End Code

@Html.Partial("_edit_category", New With {.action = "Update"})

<div id='category' class="hidden">
  <p>WARNING: A change to the category name will apply to all documents within this category.</p>
  <input type="text" />
</div>

<div id="main-body" class="management-company index">
  <h2 class="clear"> List Documents</h2>
  <p>
    This utility allows you to manage news and announcements shown on the frontpage
    of your management company web site. To add a new announcement click on the [Add
    New Announcement] button. To edit or delete an announcement click on the corresponding
    button next to it.
  </p>
  <h4> HOAs</h4>
  <div class="demo_jui">
    <table class="dataTable">
      <thead>
        <tr>
          <th> Category </th>
          <th> Title </th>
          <th> </th>
          <th> </th>
        </tr>
      </thead>
      <tbody>
        @For Each item As Hometastic.Models.Document In ViewBag.DocumentList
          @<tr>
            <td><span class="category">@item.Value("CATEGORY")</span>@Html.ActionLink("Rename", "Edit", "Category", New With {.id = item.Value("CATEGORYID")}, New With {.class = "float_right button edit_category"})</td>
            <td><div class='@item.AuthorizationLevel'>@item.Value("NAME")</div></td>
            <td>@Html.ActionLink("Edit", "Edit", "Document", New With {.id = item.Id}, New With {.class = "button"}) </td>
            <td>@Html.ActionLink("Delete", "Delete", "Document", New With {.id = item.Id}, New With {.class = "button delete_item"}) </td>
          </tr>
        Next
      </tbody>
    </table>
    @Html.ActionLink("New Document", "Create", "Document", New With {.class = "button"})
  </div>
</div>
