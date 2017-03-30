@ModelType WeCanFixIt.Models.Worker
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Worker</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Skills)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Skills)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.HoursWorked)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.HoursWorked)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Rate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Rate)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
