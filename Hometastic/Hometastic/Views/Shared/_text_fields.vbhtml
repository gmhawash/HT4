@Code
  For Each item As String() In Model.items
    @<div class="field">
      @Html.Label(item(0))
      @Html.TextBox(item(1), Model.source.Value(item(1)))
    </div>
  Next
End Code
