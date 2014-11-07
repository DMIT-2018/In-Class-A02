<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrontDesk.aspx.cs" Inherits="Staff_FrontDesk" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row col-md-12">
        <style type="text/css">
            .seating {
                display: inline-block;
                vertical-align: top;
            }

            .inline-div {
                display: inline;
            }
        </style>
        <h1>Front Desk</h1>

        <div class="well">
            <h4>Mock Date/Time</h4>
            <div class="pull-right col-md-5">
                Last Billed Date/Time:
                <asp:Repeater ID="AdHocBillDateRepeater" runat="server"
                    ItemType="System.DateTime" DataSourceID="AdHocBillDateDataSource">
                    <ItemTemplate>
                        <%# Item.ToShortDateString() %>
                        &ndash;
                        <%# Item.ToShortTimeString() %>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:ObjectDataSource runat="server" ID="AdHocBillDateDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="GetLastBillDateTime" TypeName="eRestaurant.BLL.AdHocController"></asp:ObjectDataSource>
            </div>
            <asp:TextBox ID="SearchDate" runat="server" TextMode="Date" Text="2014-10-16" />
            <asp:TextBox ID="SearchTime" runat="server" TextMode="Time" Text="13:00" CssClass="clockpicker" />
            <!-- Additional scripts/styles here (for bling) -->
            <script src="../Scripts/clockpicker.js"></script>
            <script>
                $('.clockpicker').clockpicker({ donetext: 'Accept' });
            </script>
            <link itemprop="url" href="../Content/clockpicker.css" rel="stylesheet" />
            <link itemprop="url" href="../Content/standalone.css" rel="stylesheet" />

            <asp:LinkButton ID="MockDateTime" runat="server" CssClass="btn btn-primary">Post-back new date/time</asp:LinkButton>
            <asp:LinkButton ID="MockLastBillingDateTime" runat="server" CssClass="btn btn-default" OnClick="MockLastBillingDateTime_Click">Set to last billed date/time</asp:LinkButton>
        </div>

        <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

        <div class="pull-right col-md-5">
            <details open>
                <summary>Reservations by Date/Time</summary>
                <h4>Today's Reservations</h4>
                <asp:Panel ID="ReservationSeatingPanel" runat="server" Visible='<%# ShowReservationSeating() %>'>
                    <asp:DropDownList ID="WaiterDropDownList" runat="server" CssClass="seating"
                        AppendDataBoundItems="true" DataSourceID="WaiterDataSource"
                        DataTextField="FullName" DataValueField="WaiterId">
                        <asp:ListItem Value="0">[select a waiter]</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ListBox ID="ReservationTableListBox" runat="server" CssClass="seating"
                        DataSourceID="AvailableSeatingObjectDataSource" SelectionMode="Multiple" Rows="14"
                        DataTextField="Table" DataValueField="Table"></asp:ListBox>
                </asp:Panel>
                <asp:Repeater ID="ReservationsRepeater" runat="server"
                    ItemType="eRestaurant.Entities.DTOs.ReservationCollection" DataSourceID="ReservationsDataSource">
                    <ItemTemplate>
                        <h4>
                            <%# Item.Time %>
                            <small><%# Item.Reservations.Count %> reservations at this time-slot</small>
                        </h4>
                        <asp:ListView ID="ReservationSummaryListView" runat="server"
                            OnItemCommand="ReservationSummaryListView_OnItemCommand"
                            ItemType="eRestaurant.Entities.DTOs.ReservationSummary"
                            DataSource='<%# Item.Reservations %>'>
                            <LayoutTemplate>
                                <div class="seating">
                                    <span runat="server" id="itemPlaceholder" />
                                </div>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div>
                                    <%# Item.Name %> &mdash;
                                    <%# Item.NumberInParty %> &mdash;
                                    <%# Item.Status %> &mdash;
                                    PH:
                                    <%# Item.Contact %>
                                    <asp:LinkButton ID="InsertButton" runat="server"
                                        CommandName="Seat" CommandArgument='<%# Item.ID %>'>
                                        Reservation Seating<span class="glyphicon glyphicon-plus"></span>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:ObjectDataSource runat="server" ID="ReservationsDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ReservationsByTime" TypeName="eRestaurant.BLL.SeatingController">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="SearchDate" PropertyName="Text" Name="date" Type="DateTime"></asp:ControlParameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
            </details>
        </div>

        <div class="col-md-7">
            <details open>
                <summary>Tables</summary>

                <asp:GridView ID="SeatingGridView" runat="server"
                    CssClass="table table-hover table-striped table-condensed"
                    OnSelectedIndexChanging="SeatingGridView_SelectedIndexChanging"
                    ItemType="eRestaurant.Entities.DTOs.SeatingSummary" AutoGenerateColumns="False"
                    DataSourceID="SeatingObjectDataSource">
                    <Columns>
                        <asp:CheckBoxField DataField="Taken" HeaderText="Taken" SortExpression="Taken"
                            ItemStyle-HorizontalAlign="Center"></asp:CheckBoxField>

                        <%--<asp:BoundField DataField="Table" HeaderText="Table" SortExpression="Table"></asp:BoundField>--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="TableNumber" runat="server" Text="<%# Item.Table %>" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="Seating" HeaderText="Seating" SortExpression="Seating"></asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Panel ID="WalkInSeatingPanel" runat="server"
                                    CssClass="input-group input-group-sm"
                                    Visible="<%# ! Item.Taken %>">
                                    <%--Ready to seat Walk-in customer--%>
                                    <asp:TextBox ID="NumberInParty" runat="server"
                                        CssClass="form-control col-md-1" TextMode="Number"
                                        placeholder="# people"></asp:TextBox>
                                    <span class="input-group-addon">
                                        <asp:DropDownList ID="WaiterList" runat="server"
                                            CssClass="selectpicker"
                                            AppendDataBoundItems="true" DataSourceID="WaiterDataSource" DataTextField="FullName" DataValueField="WaiterID">
                                            <asp:ListItem Value="0">[select a waiter]</asp:ListItem>
                                        </asp:DropDownList>
                                    </span>
                                    <span class="input-group-addon"
                                        style="width: 5px; padding: 0; border: 0; background-color: white;"></span>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Seat Customers"
                                        CssClass="input-group-btn" CommandName="Select"
                                        CausesValidation="false" />
                                </asp:Panel>

                                <asp:Panel ID="ReservationInfoPanel" runat="server"
                                    Visible="<%# Item.Taken %>">
                                    <%--Table occupied info here....--%>
                                    <%# Item.Waiter %>
                                    <asp:Label ID="ReservationNameLabel" runat="server"
                                        Text='<%# "&mdash; " + Item.ReservationName %>'
                                        Visible='<%# !string.IsNullOrEmpty(Item.ReservationName) %>' />

                                    <asp:Panel ID="BillInfo" runat="server" CssClass="inline-div"
                                        Visible="<%# Item.BillTotal.HasValue && Item.BillTotal.Value > 0 %>">
                                        <asp:Label ID="Label1" runat="server"
                                            Text='<%# string.Format(" &ndash; {0:C}", Item.BillTotal) %>' />
                                    </asp:Panel>

                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="BillID" HeaderText="BillID" SortExpression="BillID"></asp:BoundField>--%>
                        <%--<asp:BoundField DataField="BillTotal" HeaderText="BillTotal" SortExpression="BillTotal"></asp:BoundField>--%>
                        <%--<asp:BoundField DataField="Waiter" HeaderText="Waiter" SortExpression="Waiter"></asp:BoundField>--%>
                        <%--<asp:BoundField DataField="ReservationName" HeaderText="ReservationName" SortExpression="ReservationName"></asp:BoundField>--%>
                    </Columns>
                </asp:GridView>


            </details>
        </div>
    </div>
    <%--For the Seating GridView--%>
    <asp:ObjectDataSource runat="server" ID="SeatingObjectDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="SeatingByDateTime" TypeName="eRestaurant.BLL.SeatingController">
        <SelectParameters>
            <asp:ControlParameter ControlID="SearchDate" PropertyName="Text" Name="date" Type="DateTime"></asp:ControlParameter>
            <asp:ControlParameter ControlID="SearchTime" PropertyName="Text" DbType="Time" Name="time"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>

    <%--For the Waiter DropDown--%>
    <asp:ObjectDataSource runat="server" ID="WaiterDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllWaiters" TypeName="eRestaurant.BLL.RestaurantAdminController"></asp:ObjectDataSource>

    <%--For the Available Tables DropDown (seating reservation)--%>
    <asp:ObjectDataSource runat="server" ID="AvailableSeatingObjectDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="AvailableSeatingByDateTime" TypeName="eRestaurant.BLL.SeatingController">
        <SelectParameters>
            <asp:ControlParameter ControlID="SearchDate" PropertyName="Text" Name="date" Type="DateTime"></asp:ControlParameter>
            <asp:ControlParameter ControlID="SearchTime" PropertyName="Text" DbType="Time" Name="time"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>

