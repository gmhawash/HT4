﻿@Code
  ViewData("Title") = "Index"
  Layout = "~/Views/Shared/_ManagementCompanyLayout.vbhtml"
End Code

<h2>Index</h2>

<script type="text/javascript">
  $(function () {
    LinkToButton();

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
      var target = me.closest("div").find(".target")
      target.append(template);
      target.find(".field:last-child input[type=text]").focus();
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

    $('a.delete_question').live('click', function () {
      if (confirm("Are you sure you want to delete this question? Click 'OK' to confirm, 'Cancel' otherwise.")) {
        var question_group = $(this).closest("div.question-group");
        var id = question_group.attr("id");
        if (id != "") {
          $('#spinner').show();
          $.post('/survey/delete/' + id, function () {
            document.location.href = '@Url.Action("Index", "survey")';
          });
        }
        question_group.remove();
      }
    });

    $('input[type=submit]').click(function () {
      var results = [];
      $('#spinner').show();
      $.each($('#target .question-group'), function () {
        var me = $(this);
        var result = {}
        result.AnswerType = me.attr("type");
        result.QuestionText = me.find(".question").val();
        var answers = me.find(".target").find("input[type=text]");
        result.AnswerOptions = answers.map(function (i, e) { return $(e).val(); }).toArray();
        result.Id = me.attr("id");
        results.push(result);
      });
      $('#questions').val(JSON.stringify(results));
    });

  });
</script>

@Using Html.BeginForm("Create", "Survey")

@<div class="field">
    @Html.Label("Question Type")
    @Html.DropDownList("AnswerType", Hometastic.Models.Survey.AnswerTypeOptions)
    <a href="#" class="add_question button">Add New Question</a>
</div>
@<div id="target">
</div>

@Html.Partial("_templates")
@<div class="field">
  @Html.Hidden("questions")
  <input type="submit" value="Save" />
</div>
End Using