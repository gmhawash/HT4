@Code
  ViewData("Title") = "Hoa"
  Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<div id="services-menu">
  <ul>
    <li><a href="/Home/HOA" class="active">HOAs</a></li>
    <li><a href="/Home/MgmtCompany">MANAGEMENT COMPANIES</a></li>
    <li><a href="/Home/Vendors">VENDORS</a></li>
  </ul>
</div>
<div id="main-body">
  <h2>
    HOA Benefits</h2>
  <p>
    If your association is not managed by a company using DataTrust by Advantos software,
    it needs to be. The HOA websites have special links that allow them to pipe information
    from the DataTrust accounting and property management software right to the websites
    for viewing by the association members. The HOA websites do not work without this
    link.
  </p>
  <p>
    Our websites collect and distribute information for homeowners. It is a collection
    point where all members can go to review information posted on the website or information
    the homeowners need from the accounting back-end. Some examples of this sharing
    of information are:
  </p>
  <p>
    <img src="/Images/hoa01.gif" width="60" height="60" border="0" alt="">
    <b>Document Posting</b> Any document can be posted on the HOA website. Board meeting
    minutes, rules and regulations, CC&amp;R documents. You name it. It can be posted
    with a simple upload of a word document. And made available to all the homeowners.
  </p>
  <p>
    <img src="/Images/hoa02.gif" width="60" height="60" border="0" alt="">
    <b>Survey Section</b> Post a question with several optional answers and the homeowners
    can express their opinion. Easy to read graphs chart the results for the board to
    review.
  </p>
  <p>
    <img src="/Images/hoa03.gif" width="60" height="60" border="0" alt="">
    <b>Important Events At The Association</b> Crime information, volunteer opportunities,
    newsletters, upcoming events, calendar of events. All designed to keep association
    members better informed.
  </p>
  <p>
    <img src="/Images/hoa04.gif" width="60" height="60" border="0" alt="">
    <b>Information On Local Vendors</b> It's easy. Need local vendor services and don't
    know whom to turn to? Just click on 'Services' button and get a list of vendors
    by category. Lists their phone#, fax and email address.
  </p>
  <p>
    <img src="/Images/hoa05.gif" width="60" height="60" border="0" alt="">
    <b>Share Information With The Accounting Back-end</b> Homeowners can enter work
    order requests, sign up for automatic withdrawal from their checking account, look
    up payment histories, change their mailing address, etc. Board members can review
    all financial statements, including bankbook transactions and even the current month-to-date
    income statement!
  </p>
  @Html.Partial("_ContactFooter")
</div>
