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
    public partial class EditRegister : System.Web.UI.Page
    {

        private Customer Customer = new Customer();
        private string oldCPF;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string customerCPF = Request.QueryString["cpf"];
                Customer = Service.CustomerService.GetCustomer(customerCPF);
                oldCPF = customerCPF;
                FillFields();
            }
            else if (oldCPF == null)
            {
                string customerCPF = Request.QueryString["cpf"];
                oldCPF = customerCPF;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string cpf = CPF.Text.Replace(".", "").Replace("-", "");

            Customer.CPF = cpf;

            Customer.Sex = Convert.ToChar(DropDownSex.SelectedItem.ToString());

            var situation = DropDownSituation.SelectedItem.Text;
            Enum.TryParse(situation, out CustomerSituations resultsit);
            Customer.CustomerSituations =resultsit;

            var type = DropDownType.SelectedItem.Text;
            Enum.TryParse(type, out CustomerTypes resulttyp);
            Customer.CustomerTypes = resulttyp;

            CustomerService.EditCustomer(Customer, oldCPF);
            Response.Redirect("~/Home.aspx");
        }

        public void FillFields()
        {
            foreach (var item in Enum.GetValues(typeof(CustomerSituations)))
            {
                DropDownSituation.Items.Add(item.ToString());
            }
            foreach (var item in Enum.GetValues(typeof(CustomerTypes)))
            {
                DropDownType.Items.Add(item.ToString());
            }

            DropDownSituation.SelectedValue = Customer.CustomerSituations.ToString();
            DropDownType.SelectedValue = Customer.CustomerTypes.ToString();
            CPF.Text = Customer.CPF.ToString();
            DropDownSex.SelectedValue  = Customer.Sex.ToString();
        }
    }
}