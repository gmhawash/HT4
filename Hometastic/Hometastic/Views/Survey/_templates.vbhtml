<script type='text/template' id='selectTemplate'>
  <div class="question-group" id="{{QuestionId}}">
    <div class="float_right">
        <a href="#" class="delete_question button">Delete Question</a>
    </div>
    Question: <input type="text" class="question" value="{{QuestionText}}" />
    <div class="select-options">
      <ol class="target">
        {{#Answers}}
          <li>
            <input type="text" value={{.}} />
            <a href="#" class="delete button" >Delete</a>
          </li>
        {{/Answers}}
      </ol>
    </div>
    <a href="#" class="add button" >Add answer</a>
    <div class="hidden" target="ol">
      <li>
        <input type="text" />
        <a href="#" class="delete button" >Delete</a>
      </li>
    </div>
  </div>
</script>