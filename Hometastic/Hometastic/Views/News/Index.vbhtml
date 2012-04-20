@ModelType Hometastic.Models.News
@Code
  ViewData("Title") = "Index"
  Layout = "~/Views/Shared/_ManagementCompanyLayout.vbhtml"
End Code

<div id="main-body" class="management-company index">
  <h2 class="clear"> List News & Announcements</h2>
  <p>
    This utility allows you to manage news and announcements shown on the frontpage
    of your management company web site. To add a new announcement click on the [Add
    New Announcement] button. To edit or delete an announcement click on the corresponding
    button next to it.
  </p>
  <h4>
    HOAs</h4>

<div class="demo_jui">
  <table class="dataTable">
    <thead>
      <tr>
        <th> Title </th>
        <th> Headline</th>
        <th> Date</th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      @For Each item As Hometastic.Models.News In ViewBag.NewsList
        @<tr>
          <td>@item.Value("TITLE") </td>
          <td>@item.Value("HEADLINE") </td>
          <td>@item.CreatedDate</td>
          <td>@Html.ActionLink("Edit", "Edit", "News", New With {.id = item.Id}, New With {.id = item.Id, .class = "button"})</td>
        </tr>
      Next
    </tbody>
  </table>
  @Html.ActionLink("New Announcment", "Create", "News", New With {.class = "button"})
</div>
