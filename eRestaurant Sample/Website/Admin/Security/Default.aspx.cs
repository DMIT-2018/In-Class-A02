using eRestaurant.BLL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Security_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBindUserList();
            DataBindRoleList();
        }
    }
    private void DataBindRoleList()
    {
        // Populate the Roles Info
        RoleListView.DataSource = new RoleManager().Roles.ToList();
        RoleListView.DataBind();
    }
    private void DataBindUserList()
    {
        // Populate the Users Info
        UserListView.DataSource = new UserManager().Users.ToList();
        UserListView.DataBind();
    }

    protected void UserListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "AddWaiters":
                new UserManager().AddDefaultUsers();
                DataBindUserList();
                break;
            default:
                break;
        }
    }
    protected void RoleListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "AddDefaultRoles":
                new RoleManager().AddDefaultRoles();
                DataBindRoleList();
                break;
            default:
                break;
        }
    }
}