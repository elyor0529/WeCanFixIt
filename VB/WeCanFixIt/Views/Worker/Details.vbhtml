@ModelType WeCanFixIt.Models.Worker
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
