<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<WGSTask.Models.ContactSet>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData["Message"] %></h2>
   
    <% foreach (var m in ViewData.Model)
       { %>
        <p>
            Nama: <%= m.Name %>
            <br />
            No HP: <%= m.NoHP %>
            <br />
            <%= Html.ActionLink("Edit", "Edit", new { id = m.Id })%>
            <%= Html.ActionLink("Delete", "Delete", new { id = m.Id })%>
        </p>
            <hr />
    <% } %>

    <p>
        <%= Html.ActionLink("Add Contact", "Add") %>
    </p>
</asp:Content>
