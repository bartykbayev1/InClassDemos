using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region
using eRestaurantSystem.BLL;
using eRestaurantSystem.DAL;
using eRestaurantSystem.Entities;
using EatIn.UI;
#endregion

public partial class CommandPages_WaiterAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateHired.Text = DateTime.Today.ToShortDateString();
    }


    protected void FetchWaiter_Click(object sender, EventArgs e)
    {
        if (WaiterList.SelectedIndex == 0){
            MessageUserControl.ShowInfo("Please select a Waiter before clicking a Fetch Waiter");
        }
        else
        {
            // we will use TryRun() from MEssageUSerControl
            //this will capture error message when / if htye happen
            // and properly display in the user control
            // GEtWaiterINfo is your method for accessing Bll and Query
            MessageUserControl.TryRun((ProcessRequest)GetWaiterInfo);
        }

        
    }

    public void GetWaiterInfo()
    {
        AdminController controller = new AdminController();
        var waiter = controller.GetWaiterByID(int.Parse(WaiterList.SelectedValue));

        //var waiter = controller.GetWaiter(int.Parse(WaitersDropDown.SelectedValue));
        WaiterID.Text = waiter.WaiterID.ToString();
        FirstName.Text = waiter.FirstName;
        LastName.Text = waiter.LastName;
        Phone.Text = waiter.Phone;
        Address.Text = waiter.Address;
        DateHired.Text = waiter.HireDate.ToShortDateString();
        if (waiter.ReleaseDate.HasValue)
        {
            DateReleased.Text = waiter.ReleaseDate.Value.ToShortDateString();
            // DateReleased.Text = waiter.ReleaseDate.Value.ToString();
        }
    }

}