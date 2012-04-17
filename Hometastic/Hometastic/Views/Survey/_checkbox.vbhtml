<script type='text/template' id='multiTemplate'>
  <div class="{{AnswerType}} question-group">
    Question: <input type="text" class="question" value="{{QuestionText}}" />
    <div class="multi-options target">
        {{#AnswerOptions}}
          <div class="field">
            <input type="{{AnswerType}}" /> 
            <input type="text" value={{.}} />
            <a href="#" class="delete button" >Delete</a>
          </div>
        {{/AnswerOptions}}
    </div>
    <a href="#" class="add button" >Add answer</a>
    <div class="hidden">
       <div class="field">
         <input type="{{AnswerType}}" /> 
         <input type="text" />
        <a href="#" class="delete button" >Delete</a>
       </div>
    </div>
  </div>
</script>

<script type='text/template' id='selectTemplate'>
  <div class="{{AnswerType}} question-group">
    Question: <input type="text" class="question" value="{{QuestionText}}" />
    <div class="select-options">
      <ol class="target">
        {{#AnswerOptions}}
          <li>
            <input type="text" value={{.}} />
            <a href="#" class="delete button" >Delete</a>
          </li>
        {{/AnswerOptions}}
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