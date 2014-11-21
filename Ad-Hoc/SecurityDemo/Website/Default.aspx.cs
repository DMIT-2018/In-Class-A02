using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website;
using Microsoft.AspNet.Identity;
public partial class _Default : Page
{
    private const string STR_REGISTERED_USERS = "RegisteredUsers";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.IsAuthenticated)
        {
            string msg = "Hello " + User.Identity.Name + "!";
            UserManager m2 = new UserManager();
        var person = m2.FindByName(User.Identity.Name);
            if(m2.IsInRole(person.Id, STR_REGISTERED_USERS))
            //if (User.IsInRole(STR_REGISTERED_USERS))
            {
                msg += " I see you are in the role " + STR_REGISTERED_USERS;
                AddRoles.Visible = false;
            }
            else
            {
                msg += " Click the button to add yourself to a security role.";
                AddRoles.Visible = true;
            }
            MessageLabel.Text = msg;
        }
    }
    protected void AddRoles_Click(object sender, EventArgs e)
    {
        RoleManager manager = new RoleManager();
        var role = manager.FindByName(STR_REGISTERED_USERS);
        if (role == null)
        {
            manager.Create(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = STR_REGISTERED_USERS
                });
        }
        UserManager m2 = new UserManager();
        var person = m2.FindByName(User.Identity.Name);
        m2.AddToRole(person.Id,STR_REGISTERED_USERS);
    }
}