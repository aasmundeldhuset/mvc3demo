<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebApp.ViewModels.ArticleDetailsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Show
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Model.Title %></h2>

    <p><strong>Author:</strong> <%: Model.AuthorUserName %></p>

    <p><em><%: Model.Summary %></em></p>

    <%: Model.Body %>

    <p>
        <%: Html.ActionLink("Back to article list", "Index") %>
    </p>

</asp:Content>

