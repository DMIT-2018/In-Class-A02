<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReservationsBySpecialEvent.aspx.cs" Inherits="Admin_ReservationsBySpecialEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row col-md-12">
        <h1>Reservations by Special Event</h1>
        Special Events:
        <asp:DropDownList ID="SpecialEventDropDown" runat="server" AppendDataBoundItems="true"
             DataSourceID="SpecialEventDataSource" DataTextField="Description" DataValueField="EventCode">
            <asp:ListItem Value="-">[Select an Event]</asp:ListItem>
            <asp:ListItem Value="">[No Event]</asp:ListItem>
        </asp:DropDownList>
        <asp:LinkButton ID="ShowReservations" runat="server">Show Reservations</asp:LinkButton>
        <asp:ObjectDataSource runat="server" ID="SpecialEventDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllSpecialEvents" TypeName="eRestaurant.BLL.RestaurantAdminController"></asp:ObjectDataSource>

        <asp:GridView ID="ReservationsGridView" runat="server" AutoGenerateColumns="False" DataSourceID="ReservationDataSource">
            <Columns>
                <asp:BoundField DataField="ReservationID" HeaderText="ReservationID" SortExpression="ReservationID"></asp:BoundField>
                <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" SortExpression="CustomerName"></asp:BoundField>
                <asp:BoundField DataField="ReservationDate" HeaderText="ReservationDate" SortExpression="ReservationDate"></asp:BoundField>
                <asp:BoundField DataField="NumberInParty" HeaderText="NumberInParty" SortExpression="NumberInParty"></asp:BoundField>
                <asp:BoundField DataField="ContactPhone" HeaderText="ContactPhone" SortExpression="ContactPhone"></asp:BoundField>
                <asp:BoundField DataField="ReservationStatus" HeaderText="ReservationStatus" SortExpression="ReservationStatus"></asp:BoundField>
                <asp:BoundField DataField="EventCode" HeaderText="EventCode" SortExpression="EventCode"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource runat="server" ID="ReservationDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ReservationsBySpecialEvent" TypeName="eRestaurant.BLL.RestaurantAdminController">
            <SelectParameters>
                <asp:ControlParameter ControlID="SpecialEventDropDown" PropertyName="SelectedValue" Name="specialEventId" Type="String"></asp:ControlParameter>
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>

</asp:Content>

