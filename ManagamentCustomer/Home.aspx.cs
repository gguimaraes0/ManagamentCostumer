using ManagamentCustomer.Database;
using ManagamentCustomer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManagamentCustomer
{
    public partial class Home : Page
    {
        public List<Customer> _Customers = new List<Customer>();

        protected void Page_Load(object sender, EventArgs e)
        {
            _Customers = CustomerService.GetAllCustomers();

        }
        public Home()
        {
            _Customers = CustomerService.GetAllCustomers();

        }
        protected void RegisterCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegisterCostumer.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

            var id = ((Button)sender).CommandArgument.ToString();
            CustomerService.DeleteCustomer(id);
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}