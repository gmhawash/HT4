@ModelType Hometastic.Models.Events
@Code
  ViewData("Title") = "Index"
  Layout = "~/Views/Shared/_ManagementCompanyLayout.vbhtml"
End Code

<div id="main-body" class="management-company index">
  <h2 class="clear"> Manage Events</h2>
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
          <th> Date & Time</th>
          <th> Description</th>
          <th> </th>
          <th> </th>
        </tr>
      </thead>
      <tbody>
        @For Each item As Hometastic.Models.Events In ViewBag.EventsList
          @<tr>
            <td>
              @item.Value("EVENTDATE")
              @item.Value("EVENTTIME")
            </td>
            <td>
              @item.Value("NAME") 
              @item.Value("SHORTDESCRIPTION") 
            </td>
            <td>@Html.ActionLink("Edit", "Edit", New With {.id = item.Id}, New With {.class = "button"}) </td>
            <td>@Html.ActionLink("Delete", "Delete", New With {.id = item.Id}, New With {.class = "button delete_item"}) </td>
          </tr>
        Next
      </tbody>
    </table>
    @Html.ActionLink("New Event", "Create", New With {.class = "button"})
  </div>
</div>
