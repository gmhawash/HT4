@ModelType Hometastic.Models.Provider
@Code
  ViewData("Title") = "Index"
  Layout = "~/Views/Shared/_ManagementCompanyLayout.vbhtml"
End Code

<div id="main-body" class="management-company index">
  <h2 class="clear"> Manage Service Providers</h2>
  <p>
    This profile page provides you with all the necessary tools and information to build
    and control your management company web site as well as sites for your Homeowner
    Associations. Your contact and other information as well as links to the tools are
    listed below.
  </p>
  <h4>Service Providers</h4>
  <div class="demo_jui">
    <table class="dataTable">
      <thead>
        <tr>
          <th>ID </th>
          <th>Name</th>
          <th>Title</th>
          <th> </th>
          <th> </th>
        </tr>
      </thead>
      <tbody>
        @For Each item As Hometastic.Models.Provider In ViewBag.NewsList
          @<tr>
            <td>@item.DisplayId</td>
            <td>@item.Value("NAME") </td>
            <td>@item.Value("TITLE") </td>
            <td>@Html.ActionLink("Edit", "Edit", New With {.id = item.Id}, New With {.class = "button"}) </td>
            <td>@Html.ActionLink("Delete", "Delete", New With {.id = item.Id}, New With {.class = "button delete_item"}) </td>
          </tr>
        Next
      </tbody>
    </table>
    @Html.ActionLink("New Provider", "Create", New With {.class = "button"})
  </div>
</div>
