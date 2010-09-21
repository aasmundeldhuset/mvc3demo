<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebApp.ViewModels.ArticleDetailsModel>" %>
<%@ Import Namespace="Commons" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">NaN - Articles</asp:Content>

<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery-1.4.1-vsdoc.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#submitGrade").hide();
            $("input[type=radio].gradeValue").click(function () {
                $("#gradeForm").submit();
            });
        });
    </script>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Model.Title %></h2>

    <p>
        <strong>Author:</strong> <%: Model.AuthorUserName %><br />
        <strong>Grade average:</strong> <%: Model.GradeAverage %>
    </p>

    <p><em><%: Model.Summary %></em></p>

    <%: Model.Body %>

    <hr />

    <p>
        <%: Html.ActionLink("Back to article list", "Index") %>
    </p>

    <% if (User.IsInRole("User")) { %>
        <h3>Voice your opinion on this article</h3>

        <% using (Html.BeginForm("GradeArticle", "Grade", new {id = RouteData.Values["id"]}, FormMethod.Post, new {id = "gradeForm"})) { %>
            <% for (int grade = Constants.MinGradeValue; grade <= Constants.MaxGradeValue; ++grade) { %>
                <%= Html.RadioButton("gradeValue", grade, new {id = "gradeValue" + grade, @class = "gradeValue"}) %>
                <label for="gradeValue<%= grade %>"><%= grade %></label>
            <% } %>
            <input type="submit" id="submitGrade" value="Submit grade" />
        <% } %>
    <% } %>
</asp:Content>

