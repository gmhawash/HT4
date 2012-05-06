@ModelType Hometastic.Models.Document
@Code
  ViewData("Title") = "Index"
  Layout = "~/Views/Shared/_ManagementCompanyLayout.vbhtml"
End Code

<script type="text/javascript">
  $(function () {
    $('a.delete_item').live('click', function (event) {
      event.preventDefault();
      if (confirm("Are you sure you want to delete this news item? Click 'OK' to confirm, 'Cancel' otherwise.")) {
        var href = $(this).attr("href");
        if (href != "") {
          $('#spinner').show();
          $.post(href, function () {
            document.location.href = '@Url.Action("Index", "Document")';
          });
        }
      }
    });

    $('<div></div>').load('@Url.Action("Create", "Category")').dialog();

    $('a[category_id]').click(function () {
      var category = $(this).closest('td').find('span.category').text();
      var category_id = $(this).attr("category_id");
      $('#category input').val(category);
      $('#category').dialog({
        modal: true,
        title: "Change Categroy",
        buttons: {
          "Change": function () { $(this).dialog("close"); },
          "Cancel": function () { $(this).dialog("close"); }
        }
      });
    });
  });

</script>

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
          <th> Title </th>
          <th> Category </th>
          <th> </th>
          <th> </th>
        </tr>
      </thead>
      <tbody>
        @For Each item As Hometastic.Models.Document In ViewBag.DocumentList
          @<tr>
            <td><div class='@item.PasswordProtected'>@item.Value("NAME")</div></td>
            <td><span class="category">@item.Value("CATEGORY")</span><a class="float_right button" href="#" category_id='@item.Value("CATEGORYID")'>rename</a></td>
            <td>@Html.ActionLink("Edit", "Edit", "Document", New With {.id = item.Id}, New With {.class = "button"}) </td>
            <td>@Html.ActionLink("Delete", "Delete", "Document", New With {.id = item.Id}, New With {.class = "button delete_item"}) </td>
          </tr>
        Next
      </tbody>
    </table>
    @Html.ActionLink("New Document", "Create", "Document", New With {.class = "button"})
  </div>
</div>
