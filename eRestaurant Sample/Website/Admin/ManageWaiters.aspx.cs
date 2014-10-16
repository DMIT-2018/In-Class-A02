using eRestaurant.BLL;
using eRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageWaiters : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ShowWaiter_Click(object sender, EventArgs e)
    {

    }
    protected void Add_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun(AddWaiter, "Waiter Added", "The new waiter was successfully added");
    }

    public void AddWaiter()
    {
        Waiter person = new Waiter()
        {
            FirstName = FirstName.Text,
            LastName = LastName.Text,
            Address = Address.Text,
            Phone = Phone.Text,
            HireDate = DateTime.Parse(HireDate.Text)
        };
        DateTime temp;
        if (DateTime.TryParse(ReleaseDate.Text, out temp))
            person.ReleaseDate = temp;
        var controller = new RestaurantAdminController();
        person.WaiterID = controller.AddWaiter(person);
        WaiterID.Text = person.WaiterID.ToString();
    }

    protected void Update_Click(object sender, EventArgs e)
    {

    }
    protected void Delete_Click(object sender, EventArgs e)
    {

    }
    protected void Clear_Click(object sender, EventArgs e)
    {

    }
}