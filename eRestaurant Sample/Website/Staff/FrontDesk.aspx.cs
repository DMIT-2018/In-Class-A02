using eRestaurant.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_FrontDesk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void MockLastBillingDateTime_Click(object sender, EventArgs e)
    {
        var controller = new AdHocController();
        DateTime info = controller.GetLastBillDateTime();
        // Format the DateTime object to work with the HTML5 <input type="date" />
        SearchDate.Text = info.ToString("yyyy-MM-dd"); // This is the format for a date
        // Format the DateTime object to work with the HTML5 <input type="time" />
        SearchTime.Text = info.ToString("HH:mm:ss"); // HH is 24 hour clock, hh is 12 hour clock
    }
}