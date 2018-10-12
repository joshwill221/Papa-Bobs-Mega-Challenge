using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobs.Web
{
    public partial class OrderManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refreshGridView();
        }

        protected void ordersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Convert the event arugment (row number clicked) to an int.
            int index = Convert.ToInt32(e.CommandArgument);
            // Assigned as a GridViewRow object so can be referenced directly.
            GridViewRow row = ordersGridView.Rows[index];
            // Get rowGUID (column 2) of the row clicked.
            var value = row.Cells[1].Text.ToString();

            var orderId = Guid.Parse(value);
            Domain.OrderManager.CompleteOrder(orderId);
            refreshGridView();
        }

        private void refreshGridView()
        {
            var orders = Domain.OrderManager.GetOrders();
            ordersGridView.DataSource = orders;
            ordersGridView.DataBind();
        }
    }
}