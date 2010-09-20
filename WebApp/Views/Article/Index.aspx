<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebApp.ViewModels.ArticleViewModel>>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">NaN - Articles</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <h2>Articles</h2>

    <p><%: Html.ActionLink("Create new article", "Create") %></p>

    <table>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Summary</th>
        </tr>

        <% foreach (var article in Model) { %>
    
            <tr>
                <td><%: Html.ActionLink(article.Title, "Index", new { id = article.Id }) %></td>
                <td><%: article.AuthorUserName %></td>
                <td><%: article.Summary %></td>
            </tr>

        <% } %>

    </table>

</asp:Content>
