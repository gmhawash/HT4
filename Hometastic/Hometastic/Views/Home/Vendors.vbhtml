@Code
  ViewData("Title") = "Services"
  Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<div id="services-menu">
  <ul>
    <li><a href="/Home/HOA">HOAs</a></li>
    <li><a href="/Home/MgmtCompany">MANAGEMENT COMPANIES</a></li>
    <li><a href="/Home/Vendors" class="active">VENDORS</a></li>
  </ul>
</div>
<div id="main-body">
  <h2>
    Vendor Benefits</h2>
  <p>
    Our management company clients are located throughout the United States. They manage
    homeowners associations within their local area. These management companies have
    <b>websites created through Hometastic</b> for each of their associations.
  </p>
  <p>
    <img src="/Images/ven.jpg" alt="Vendors" />
    Each of these associations have a high degree of participation by their members
    on their website. Homeowners often go to their website to look at minutes of meetings,
    legal documents, review their payment history, enter work order requests, review
    association financial statements and communicate with other homeowners. Since <b>homeowners
    are always looking for information on vendors to use</b>, they also visit their
    site often to look up information on local vendors!
    </p>
  <p>
    You can select a management company and advertise on all the websites their associations
    have on the Hometastic network. This advertising includes <b>banner ads</b> that
    are displayed on each website, as well as a <b>vendor corner on each site</b> that
    lists vendor services and displays an individual vendor profile and contact resource
    for each vendor. 
    </p>
  <p>
    
    It's a perfect way to advertise locally and conduct business with
    homeowners on a local level! We charge you only for the advertising that you use,
    and the payment is withdrawn from your checking account automatically each month.
  </p>
  @Html.Partial("_ContactFooter")
</div>
