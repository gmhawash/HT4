@Code
  ViewData("Title") = "Index"
  Layout = "~/Views/Shared/_ManagementCompanyLayout.vbhtml"
End Code

<h2>Index</h2>

<script type="text/javascript">
  $(function () {
    var jsonResponse = $.get('@Url.Action("surveylist", "survey")', function (data) {
      var questions = eval(data);
      $.each(questions, function (i, e) {
        var templateId = e.AnswerType == 'select' ? '#selectTemplate' : '#multiTemplate';
        var html = Mustache.to_html($(templateId).html(), e);
        $("#target").append(html);
        LinkToButton();
      });
    });

    $("a.add").live("click", function () {
      var me = $(this);
      var template = me.next().html();
      me.closest("div").find(".target").append(template);
    });

    $("a.delete").live("click", function () {
      $(this).closest("li").remove();
    });

    $('a.add_question').click(function () {
      var answerType = $('#AnswerType option:selected').val();
      var templateId = answerType == 'select' ? '#selectTemplate' : '#multiTemplate';
      var html = Mustache.to_html($(templateId).html(), { QuestionText: "", AnswerOptions: [], AnswerType: answerType });
      $("#target").append(html);
      LinkToButton();
    });
  });
</script>

@Using Html.BeginForm()

@<div id="target">
</div>

@Html.Partial("_checkbox")
@<div class="field">
    @Html.Label("Question Type")
    @Html.DropDownList("AnswerType", Hometastic.Models.Survey.AnswerTypeOptions)
    <a href="#" class="add_question button">Add New Question</a>
</div>
@<div class="field">
  <input type="submit">Save</input>
</div>
End Using