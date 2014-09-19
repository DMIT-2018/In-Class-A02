<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageWaiters.aspx.cs" Inherits="Admin_ManageWaiters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script src='<%=ResolveUrl("/Scripts/unobtrusive-DMIT-2018.js") %>'></script>
    <div class="row col-md-12">
        <h1>Manage Waiters</h1>
    </div>
    <div data-style="bootstrap">
        <fieldset data-style="inline">
            <asp:Label ID="Label1" runat="server" Text="Select Waiter" AssociatedControlID="WaitersDropDown" />
            <asp:DropDownList ID="WaitersDropDown" runat="server"></asp:DropDownList>
            <asp:LinkButton ID="ShowWaiter" runat="server" Text="Show Waiter"/>
        </fieldset>

        <blockquote>
            <asp:Label ID="MessageLabel" runat="server" CssClass="label label-default" />
        </blockquote>

        <fieldset>
            <asp:Label ID="Label2" runat="server" Text="Waiter ID" AssociatedControlID="WaiterID" />
            <asp:TextBox ID="WaiterID" runat="server" Enabled="false"></asp:TextBox>

            <asp:Label ID="Label3" runat="server" Text="First Name" AssociatedControlID="FirstName" />
            <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>

            <asp:Label ID="Label4" runat="server" Text="Last Name" AssociatedControlID="LastName" />
            <asp:TextBox ID="LastName" runat="server"></asp:TextBox>

            <asp:Label ID="Label5" runat="server" Text="Phone" AssociatedControlID="Phone" />
            <asp:TextBox ID="Phone" runat="server"></asp:TextBox>

            <asp:Label ID="Label6" runat="server" Text="Address" AssociatedControlID="Address" />
            <asp:TextBox ID="Address" runat="server"></asp:TextBox>

            <asp:Label ID="Label7" runat="server" Text="Hire Date" AssociatedControlID="HireDate" />
            <asp:TextBox ID="HireDate" runat="server"></asp:TextBox>

            <asp:Label ID="Label8" runat="server" Text="Release Date" AssociatedControlID="ReleaseDate" />
            <asp:TextBox ID="ReleaseDate" runat="server"></asp:TextBox>
        </fieldset>

        <fieldset data-style="btn">
            <asp:LinkButton ID="Add" runat="server" Text="Add Waiter" />
            <asp:LinkButton ID="Update" runat="server" Text="Update Waiter" />
            <asp:LinkButton ID="Delete" runat="server" Text="Delete Waiter" />
            <asp:LinkButton ID="Clear" runat="server" Text="Clear Fields" />
        </fieldset>
    </div>
</asp:Content>

