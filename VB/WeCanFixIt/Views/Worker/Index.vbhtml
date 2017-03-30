@ModelType IEnumerable(Of WeCanFixIt.Models.Worker)
@Code
    ViewData("Title") = "List of Workers"
End Code

@section Styles{
    <link href="/Plugins/DataTables/media/css/dataTables.bootstrap.min.css" rel="stylesheet" />
End Section

<h2>List of Workers</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>

<table class="table" id="datatable">
    <thead>
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Name)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Skills)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.HoursWorked)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Rate)
            </th>
            <th></th>
        </tr>
    </thead>

    <tbody>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Name)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Skills)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.HoursWorked)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Rate)
                </td>
                <td>
                    @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
                    @Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
                    @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
                </td>
            </tr>
        Next
    </tbody>

</table>

 
@Section Scripts
    <script src="/Plugins/DataTables/media/js/jquery.dataTables.min.js"></script>
    <script src="/Plugins/DataTables/media/js/dataTables.bootstrap.min.js"></script>
    <script>
        $(function () {
            $("#datatable").dataTable();
        });
    </script>
End Section
