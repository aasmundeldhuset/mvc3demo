<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebApp.ViewModels.ArticleDetailsModel>" %>
<%@ Import Namespace="Commons" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">NaN - Articles</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Model.Title %></h2>

    <p><strong>Author:</strong> <%: Model.AuthorUserName %></p>

    <p><em><%: Model.Summary %></em></p>

    <%: Model.Body %>

    <hr />

    <p>
        <%: Html.ActionLink("Back to article list", "Index") %>
    </p>

    <h3>Voice your opinion on this article</h3>

    <% using (Html.BeginForm("GradeArticle", "Grade")) { %>
        <% for (int grade = Constants.MinGradeValue; grade <= Constants.MaxGradeValue; ++grade) { %>
            <%= Html.RadioButton("gradeValue", grade, new {id = "gradeValue" + grade}) %>
            <label for="gradeValue<%= grade %>"><%= grade %></label>
        <% } %>
        <input type="submit" value="Submit grade" />
    <% } %>

</asp:Content>

