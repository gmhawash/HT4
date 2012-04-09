@ModelType Hometastic.Models.ManagementCompanyUser

@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_ManagementCompanyLayout.vbhtml"
End Code
<div id="main-body">
<h2>Manage Clients</h2>
<p>

This profile page provides you with all the necessary tools and information to build and control your management company web site as well as sites for your Homeowner Associations. Your contact and other information as well as links to the tools are listed below.
</p>

<h4>HOAs</h4>
<table>
    <tr>
        <th>Id</th>
        <th>Name</th>
        <th>Address</th>
    </tr>
    @For Each item As Hometastic.Models.HoaUser In ViewBag.HoaList
        @<tr>
        <td>@item.id </td>
        <td>@item.name </td>
        <td>@item.formattedAddress</td>
        </tr>
    Next

</table>

<h4>BANNER PROVIDERS</h4>
<table>
    <tr>
        <th></th>
    </tr>
</table>
</div>