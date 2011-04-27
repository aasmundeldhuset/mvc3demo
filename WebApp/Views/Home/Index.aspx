<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">NaN - Home Page</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome to Nerds at NNUG!</h2>
    <p>Feel free to <%= Html.ActionLink("browse the articles", "Index", "Article") %>.</p>
</asp:Content>
