<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - WeCanFixIt</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    @RenderSection("Styles", False)
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("WeCanFixIt", "Index", "Home", New With {.area = ""}, New With { .Class = "navbar-brand" })
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    @If Request.IsAuthenticated Then
                        @<li>@Html.ActionLink("Jobs", "Index", "Job")</li>
                        @<li>@Html.ActionLink("Employees", "Index", "Worker")</li>
                    End If
                </ul>
                @Html.Partial("_LoginPartial")
            </div>
        </div>
    </div>
    <div Class="container body-content"> 
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - WeCanFixIt</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("Scripts", False)
</body>
</html>
