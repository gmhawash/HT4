@Code
  ViewData("Title") = "Index"
  Layout = "~/Views/Shared/_ManagementCompanyLayout.vbhtml"
End Code

<h2>Index</h2>

<script type="text/javascript">
  $(function () {
    LinkToButton();

    var jsonResponse = $.get('@Url.Action("Surveylist")', function (data) {
      var questions = eval(data);
      $.each(questions, function (i, e) {
        var templateId = '#selectTemplate'
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
      var templateId = '#selectTemplate';
      var html = Mustache.to_html($(templateId).html(), { QuestionText: "", AnswerOptions: [] });
      $("#target").append(html);
      LinkToButton();
    });

    $('a.delete_question').live('click', function () {
      if (confirm("Are you sure you want to delete this question? Click 'OK' to confirm, 'Cancel' otherwise.")) {
        var question_group = $(this).closest("div.question-group");
        var id = question_group.attr("id");
        if (id != "") {
          $.post('/survey/delete/' + id, function () {
         //   document.location.href = '@Url.Action("Index", "survey")';
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
        result.AnswerType = me.find("select.question_type").val();
        result.QuestionText = me.find(".question").val();
        var answers = me.find(".target").find("input[type=text]");
        result.Answers = answers.map(function (i, e) { return $(e).val(); }).toArray();
        result.Id = me.attr("id") || "";
        results.push(result);
      });
      $('#questions').val(JSON.stringify(results));
    });

    $('select.question_type').live('change', function () {
      var group = $(this).closest('div.question-group');
      var answer = CollectAnswer(group);
      RenderTemplate($(this), answer, group);
      LinkToButton();
    });

    function RenderTemplate(me, answer, group) {
      var templateId = me.val() == 'select' ? '#selectTemplate' : '#multiTemplate';
      answer.AnswerType = me.val();
      var html = Mustache.to_html($(templateId).html(), answer);
      group.children().replaceWith($(html).children());

      // set selected option in select box.
      group.find('select').val(answer.AnswerType);
    }

    function CollectAnswer(me) {
      var result = {}
      result.AnswerType = me.find("select.question_type").val();
      result.QuestionText = me.find(".question").val();
      var answers = me.find(".target").find("input[type=text]");
      result.Answers = answers.map(function (i, e) { return $(e).val(); }).toArray();
      result.QuestionId = me.attr("id");
      return result;
    }
  });
</script>

@Using Html.BeginForm("Create", "Survey")
  @<div class="field">
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

  <div class="demo_jui">
    <table class="dataTable">
      <thead>
        <tr>
          <th>ID</th>
          <th>Question</th>
          <th>Created On</th>
          <th>Activated On</th>
          <th># of Votes</th>
          <th>Current?</th>
          <th>Active?</th>
          <th></th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        @For Each item As Hometastic.Models.Survey In ViewBag.SurveyList
          @<tr>
              <td>@item.Id</td>
              <td>@item.QuestionText</td>
              <td>@item.CreatedOn</td>
              <td>@item.ActivatedOn</td>
              <td>@item.Value("VOTES")</td>
              <td>Current?</td>
              <td>Active?</td>
            <td>@Html.ActionLink("Edit", "Edit", "Document", New With {.id = item.Id}, New With {.class = "button"}) </td>
            <td>@Html.ActionLink("Delete", "Delete", "Document", New With {.id = item.Id}, New With {.class = "button delete_item"}) </td>
          </tr>
        Next
      </tbody>
    </table>
    @Html.ActionLink("New Document", "Create", "Document", New With {.class = "button"})
  </div>
</div>