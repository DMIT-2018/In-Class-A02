<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Security_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row jumbotron">
        <h1>Site Administration</h1>
    </div>
    <div class="row">
        <div class="col-md-9">
            <h2>Users</h2>
            <asp:ListView ID="UserListView" runat="server"
    ItemType="eRestaurant.Entities.Security.ApplicationUser"
    OnItemCommand="UserListView_ItemCommand">
    <EmptyDataTemplate>
        <table runat="server">
            <tr>
                <td>
                    No users in this site.
                    <asp:LinkButton runat="server" CommandName="AddWaiters" Text="Add Waiters as users" ID="AddWaitersButton" />
                </td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:LinkButton runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                <asp:LinkButton runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
            </td>
            <td>
                <asp:Label Text='<%# Item.UserName %>' runat="server" ID="UserNameLabel" /></td>
            <td>
                <asp:Label Text='<%# Item.Email %>' runat="server" ID="EmailLabel" /></td>
            <td><em>password is hashed</em></td>
            <td>
                <asp:Label Text='<%# Item.WaiterID %>' runat="server" ID="WaiterIDLabel" />
                <asp:DropDownList ID="WaiterIDDropDown_Item" runat="server"
                    AppendDataBoundItems="true" SelectedValue='<%# Item.WaiterID %>'
                    DataSourceID="WaiterDataSource" Enabled="false"
                    DataTextField="FullName" DataValueField="WaiterID">
                    <asp:ListItem Value="">[none]</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label runat="server" ID="RolesCountLabel"
                    Text='<%# string.Join(", ", Item.Roles.Select(x=>x.RoleId).ToArray()) %>' />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table runat="server" id="itemPlaceholderContainer"
                        class="table table-condensed table-hover table-striped">
                        <tr runat="server">
                            <th runat="server">Action</th>
                            <th runat="server">User Name</th>
                            <th runat="server">Email</th>
                            <th runat="server">Password</th>
                            <th runat="server">Waiter</th>
                            <th runat="server">Roles</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server">
                    <asp:DataPager runat="server" ID="DataPager1">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"></asp:NextPreviousPagerField>
                        </Fields>
                    </asp:DataPager>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
</asp:ListView>
        </div>
        <div class="col-md-3">
            <h2>Roles</h2>
            <asp:ListView ID="RoleListView" runat="server"
    ItemType="Microsoft.AspNet.Identity.EntityFramework.IdentityRole"
    OnItemCommand="RoleListView_ItemCommand">
    <EmptyDataTemplate>
        <table runat="server">
            <tr>
                <td>
                    No roles in this site.
                    <asp:LinkButton runat="server" CommandName="AddDefaultRoles" Text="Add default security roles" ID="AddDefaultRolesButton" />
                </td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:LinkButton runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                <asp:LinkButton runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
            </td>
            <td><asp:Label Text='<%# Item.Name %>' runat="server" ID="NameLabel" /></td>
            <td><asp:Label Text='<%# Item.Users.Count %>' runat="server" ID="UsersCountLabel" /></td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table runat="server" id="itemPlaceholderContainer"
                        class="table table-condensed table-hover table-striped">
                        <tr runat="server">
                            <th runat="server">Action</th>
                            <th runat="server">Role Name</th>
                            <th runat="server">Users</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server">
                    <asp:DataPager runat="server" ID="DataPager2">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"></asp:NextPreviousPagerField>
                        </Fields>
                    </asp:DataPager>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
</asp:ListView>
        </div>
    </div>
    <%--List of Waiters--%>
    <asp:ObjectDataSource runat="server" ID="WaiterDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllWaiters" TypeName="eRestaurant.BLL.RestaurantAdminController"></asp:ObjectDataSource>
</asp:Content>

