@ModelType MGAU_KnightExchange_ITEC4286.Models.products
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>products</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.myUsers.user_lname)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.myUsers.user_lname)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.product_info.product_name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.product_info.product_name)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.product_id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
