using ManagamentCostumer.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace ManagamentCostumer
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var a = CostumerService.GetCustomers();

            ListCustomers.DataSource = a;
            ListCustomers.DataBind();

            //  Table1.Rows.AddRange(a);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegisterCostumer.aspx");
        }
    }
}