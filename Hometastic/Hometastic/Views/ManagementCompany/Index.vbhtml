@ModelType Hometastic.Models.ManagementCompanyUser
@Code
  ViewData("Title") = "Index"
  Layout = "~/Views/Shared/_ManagementCompanyLayout.vbhtml"
End Code

<div id="main-body" class="management-company index">
  <h2>Site Images</h2>
  <div id="logo-container">
    @Html.Partial("_edit_images",
                   New With {.purpose = "logo",
                             .title = "Upload Logo",
                             .image_path = Model.LogoPath,
                             .url = Url.Action("Upload", "ManagementCompany")
                            }) 
  </div>
  <div id="front-image-container">
    @Html.Partial("_edit_images",
                   New With {.purpose = "front-image",
                             .title = "Upload Front Image",
                             .image_path = Model.FrontPagePath,
                             .url = Url.Action("Upload", "ManagementCompany")
                            }) 
  </div>
  
  <h2 class="clear"> Manage Clients</h2>
  <p>
    This profile page provides you with all the necessary tools and information to build
    and control your management company web site as well as sites for your Homeowner
    Associations. Your contact and other information as well as links to the tools are
    listed below.
  </p>
  <h4>
    HOAs</h4>

<div class="demo_jui">
  <table class="dataTable">
    <thead>
      <tr>
        <th> Id </th>
        <th> Name</th>
        <th> Address</th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      @For Each item As Hometastic.Models.HoaUser In ViewBag.HoaList
        @<tr>
          <td>@item.id </td>
          <td>@item.name </td>
          <td>@item.formattedAddress </td>
          <td>@Html.ActionLink("Edit", "Edit", "Hoa", New With {.id = item.id}, New With {.class = "button"})</td>
        </tr>
      Next
    </tbody>
  </table>
  <h4>
    BANNER PROVIDERS</h4>
  <table class="dataTable">
    <thead>
      <tr>
        <th> Id </th>
        <th> Name </th>
        <th> Address </th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      @For Each item As Hometastic.Models.VendorUser In ViewBag.VendorList
        @<tr>
          <td>@item.id </td>
          <td>@item.name </td>
          <td>@item.formattedAddress </td>
          <td>@Html.ActionLink("Edit", "Edit", "Vendor", New With {.id = item.id}, New With {.class = "button"})</td>
        </tr>
      Next
    </tbody>
  </table>
  </div>
</div>
