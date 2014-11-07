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

    protected void SeatingGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        // Seat walk-in customers
        MessageUserControl.TryRun(() =>
        {
            // TODO: There are a lot of assumptions in parsing the input, and it would be better
            //       to break this into chunks an display appropriate "usage" messages to the end-user.
            // Get the controls
            GridViewRow row = SeatingGridView.Rows[e.NewSelectedIndex];
            var tableControl = row.FindControl("TableNumber") as Label;
            var numberInPartyControl = row.FindControl("NumberInParty") as TextBox;
            var waiterListControl = row.FindControl("WaiterList") as DropDownList;
            var when = DateTime.Parse(SearchDate.Text).Add(TimeSpan.Parse(SearchTime.Text));
            // Seat the customer
            var controller = new SeatingController();
            controller.SeatCustomer(when, byte.Parse(tableControl.Text), int.Parse(numberInPartyControl.Text), int.Parse(waiterListControl.SelectedValue));
            // Refresh the gridview
            SeatingGridView.DataBind();
        }, "Customer Seated", "New walk-in customer has been seated");
    }

    protected void ReservationSummaryListView_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {
        // Check the command name and add the reservation for the specified seats.
        if (e.CommandName.Equals("Seat"))
        {
            MessageUserControl.TryRun(() =>
            {
                // Get the data
                var reservationId = int.Parse(e.CommandArgument.ToString());
                var selectedItems = new List<byte>();
                foreach (ListItem item in ReservationTableListBox.Items)
                {
                    if (item.Selected)
                        selectedItems.Add(byte.Parse(item.Text.Replace("Table ", "")));
                }
                var when = DateTime.Parse(SearchDate.Text).Add(TimeSpan.Parse(SearchTime.Text));
                // Seat the reservation customer
                var controller = new SeatingController();
                controller.SeatCustomer(when, reservationId, selectedItems, int.Parse(WaiterDropDownList.SelectedValue));
                // Refresh the gridview
                SeatingGridView.DataBind();
            }, "Customer Seated", "Reservation customer has arrived and has been seated");
        }
    }

    protected bool ShowReservationSeating()
    {
        // TODO: Get the reservations for the day and return true if there are reservations, false otherwise
        return false;
    }
}