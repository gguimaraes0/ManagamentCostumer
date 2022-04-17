using ManagamentCustomer.Database;
using ManagamentCustomer.Service;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManagamentCustomer
{
    public partial class Home : Page
    {
        public List<Customer> _Customers = new List<Customer>();
        private bool isRefresh = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillFieldsTable();
        }
        private void FillFieldsTable()
        {
            _Customers.Clear();
            _Customers = CustomerService.GetAllCustomers();
            if (!IsPostBack || isRefresh)
            {
                repCustomer.DataSource = _Customers;
                repCustomer.DataBind();
            }
        }
        protected void RegisterCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegisterCostumer.aspx");
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            var id = ((Button)sender).CommandArgument.ToString();
            CustomerService.DeleteCustomer(id);
            Response.Redirect("~/Home.aspx");
        }
        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            var id = ((Button)sender).CommandArgument.ToString();
            Response.Redirect("~/EditRegister.aspx?cpf="+ id);
        }

        protected void SearchById_Click(object sender, EventArgs e)
        {
            _Customers.Clear();
            string cpf = inputCPF.Text;
            cpf = cpf.Replace(".", "").Replace("-", "");
            Customer customer = CustomerService.GetCustomer(cpf);
            _Customers.Add(customer);

            repCustomer.DataSource = _Customers;
            repCustomer.DataBind();

        }

        protected void ClearSearch_Click(object sender, EventArgs e)
        {
            isRefresh = true;
            FillFieldsTable();
            inputCPF.Text ="";
            isRefresh = false;
        }
    }
}