@Code
  ViewData("Title") = "Services"
  Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<div id="services-menu">
  <ul>
    <li><a href="/Home/HOA">HOAs</a></li>
    <li><a href="/Home/MgmtCompany" class="active">MANAGEMENT COMPANIES</a></li>
    <li><a href="/Home/Vendors">VENDORS</a></li>
  </ul>
</div>
<div id="main-body">
  <h2>
    Management Company Benefits</h2>
  <p>
    Management companies using the DataTrust by Advantos Property Management Software
    system can use Hometastic websites for all their associations. This low cost, additional
    software product has many advantages for the management company:
  </p>
  <div>
    <span>
      <img src="/Images/mgmt01.gif" width="60" height="60" border="0" alt=""></span>
    <span><b>The HOA websites can be synchronized with your own corporate website to provide
      seamless transfers and a professional appearance.</b> If you don't have a company
      web site, we'll create it for you in minutes. If you do, that's ok. Either way,
      homeowners can go to your website, put in their information, and the software will
      take them right to their HOA website, complete with your logo in the top corner.
      It's seamless, professional looking, and impresses both your clients and your prospects.
    </span>
  </div>
  <div>
    <span><img src="/Images/mgmt02.gif" width="60" height="60" border="0" alt=""></span>
    <span><b>Dramatically improve the success of your presentations, bringing on new HOA customers
      faster than you ever imagined. Show your prospects new capabilities of these HOA
      websites.</b>
    <br />
    Show how homeowners can look up their payment history. Or how they can enter work
    order requests or change their mailing address or sign up for automatic withdrawal
    from their checking account and how this automatically changes the information in
    the back-end accounting system! For a real eye-opener, how about showing them how
    board members can review financial statements or running bank accounts for any month
    and year desired - even the current month-to-date. Or how about delinquent aging
    reports - it's all real-time and is updated instantly as information is posted.
    The demonstration and the business is yours, since you are the only company offering
    these services!</span>
  </div>
  <div>
    <span><img src="/Images/mgmt03.gif" width="60" height="60" border="0" alt=""></span>
    <span><b>Reduce the calls and administrative work your staff performs. </b>
    <br />
    With more and more administrative functions being performed by homeowners on their
    website, that means less time your staff must spend changing addresses, signing
    people up for ACH or answering questions about payments. </span>
  </div>
  <div>
    <span><img src="/Images/mgmt03.gif" width="60" height="60" border="0" alt=""></span>
    <span><b>Once your clients get used to these services, you have them for life. </b>
    <br />
    Once board members become used to reviewing current financial statements on-line,
    once homeowners realize they can look up payment histories, change addresses and
    sign up for ACH through their website, it is very difficult to go without these
    services. It is a hook that is very hard for your competitors to duplicate and your
    customers to give up!</span>
  </div>
  @Html.Partial("_ContactFooter")
</div>
