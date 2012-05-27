@Code
  ViewData("Title") = "Contact Us"
End Code
<div id="main-body">
  <h2>
    Contact Us</h2>
  <p>
    Your questions and comments about this site and your visit are important. Feel free
    to contact us at any time. You may wish to send us your comments now, using the
    form below. Simply enter your information and click [Send]. Alternatively, we welcome
    your email at <a href="mailto:info@hometastic.com">info@hometastic.com</a>.
  </p>
  <div id="contact-us">
    @Using Html.BeginForm("ContactUs", "Home")
      @<label >Name </label>
      @Html.TextBox("Name")

      @<label >Email </label>
      @Html.TextBox("Email")          

      @<label >Phone </label>
      @Html.TextBox("Phone")          

      @<label >Message </label>
      @Html.TextArea("Message")          

      @<div id="action" class="clear">
        <label>&nbsp;</label>
        <input type="submit" value="Send" />
      </div>
    End Using
  </div>
  <div id="contact-info">
    <p>
      <img src="/Images/i_letter.gif"  alt=""/>
      P.O. Box 3545<br />
        Lacey, WA 98509-3545
    </p>
    <p>
      <img src="/Images/i_phone.gif"  alt=""/>
      Phone: (760) 944-55705<br />
        Fax: (760) 655-1583
    </p>
  </div>
</div>
