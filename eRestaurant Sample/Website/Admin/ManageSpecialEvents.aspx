<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageSpecialEvents.aspx.cs" Inherits="Admin_ManageSpecialEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row col-md-12">
        <h1>Manage Special Events</h1>
    </div>
    <asp:ListView ID="ListView1" runat="server" DataSourceID="SpecialEventDataSource" InsertItemPosition="LastItem">
        <EditItemTemplate>
            <span style="">EventCode:
                <asp:TextBox Text='<%# Bind("EventCode") %>' runat="server" ID="EventCodeTextBox" /><br />
                Description:
                <asp:TextBox Text='<%# Bind("Description") %>' runat="server" ID="DescriptionTextBox" /><br />
                <asp:CheckBox Checked='<%# Bind("Active") %>' runat="server" ID="ActiveCheckBox" Text="Active" /><br />
                Reservations:
                <asp:TextBox Text='<%# Bind("Reservations") %>' runat="server" ID="ReservationsTextBox" /><br />
                <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" /><asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" /><br />
                <br />
            </span>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <span>No data was returned.</span>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <span style="">EventCode:
                <asp:TextBox Text='<%# Bind("EventCode") %>' runat="server" ID="EventCodeTextBox" /><br />
                Description:
                <asp:TextBox Text='<%# Bind("Description") %>' runat="server" ID="DescriptionTextBox" /><br />
                <asp:CheckBox Checked='<%# Bind("Active") %>' runat="server" ID="ActiveCheckBox" Text="Active" /><br />
                Reservations:
                <asp:TextBox Text='<%# Bind("Reservations") %>' runat="server" ID="ReservationsTextBox" /><br />
                <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" /><asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" /><br />
                <br />
            </span>
        </InsertItemTemplate>
        <ItemTemplate>
            <div style="">
                <asp:LinkButton runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                &nbsp;&nbsp;
                <asp:LinkButton runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                &nbsp;&nbsp;&nbsp;
                <asp:CheckBox Checked='<%# Eval("Active") %>' runat="server" ID="ActiveCheckBox" Enabled="false" Text="Active" />
                &mdash;
                EventCode:
                <asp:Label Text='<%# Eval("EventCode") %>' runat="server" ID="EventCodeLabel" />
                &mdash;
                Description:
                <asp:Label Text='<%# Eval("Description") %>' runat="server" ID="DescriptionLabel" />
            </div>
        </ItemTemplate>
        <LayoutTemplate>
            <fieldset runat="server" id="itemPlaceholderContainer">
                <div runat="server" id="itemPlaceholder" />
            </fieldset>
        </LayoutTemplate>
    </asp:ListView>
    <asp:ObjectDataSource runat="server" ID="SpecialEventDataSource" DataObjectTypeName="eRestaurant.Entities.SpecialEvent" DeleteMethod="DeleteSpecialEvent" InsertMethod="AddSpecialEvent" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllSpecialEvents" TypeName="eRestaurant.BLL.RestaurantAdminController" UpdateMethod="UpdateSpecialEvent"></asp:ObjectDataSource>
</asp:Content>

