@ModelType IEnumerable(Of MGAU_KnightExchange_ITEC4286.Models.products)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.myUsers.user_lname)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.product_info.product_name)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.myUsers.user_lname)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.product_info.product_name)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.product_id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.product_id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.product_id })
        </td>
    </tr>
Next

</table>
