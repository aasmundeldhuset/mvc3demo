<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Domain.Article>" %>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server">NaN - Edit article</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit article</h2>

    <% using (Html.BeginForm()) { %>

        <%: Html.ValidationSummary(true) %>
        
        <%: Html.HiddenFor(model => model.Id) %>
            
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Title) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Title) %>
            <%: Html.ValidationMessageFor(model => model.Title) %>
        </div>
            
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Summary) %>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.Summary, 4, 100, null) %>
            <%: Html.ValidationMessageFor(model => model.Summary) %>
        </div>
            
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Body) %>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.Body, 30, 100, null) %>
            <%: Html.ValidationMessageFor(model => model.Body) %>
        </div>

        <p><input type="submit" value="Save" /></p>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to article list", "Index") %>
    </div>

</asp:Content>

