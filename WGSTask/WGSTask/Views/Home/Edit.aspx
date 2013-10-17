<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WGSTask.Models.ContactSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Add
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add Contact</h2>

    <form method="post" action="/Home/Edit">

    <!-- Include Hidden Id -->
    <%= Html.Hidden("id") %>

    Title:
    <br />
    <%= Html.TextBox("name") %>
    
    <br /><br />
    Director:
    <br />
    <%= Html.TextBox("nohp") %>
    
    <br /><br />
    <input type="submit" value="Edit Contact" />
</form>

</asp:Content>
