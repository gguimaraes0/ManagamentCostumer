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
                Customer = CustomerService.GetCustomer(customerCPF);
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


            string result = "";
            if (ValidateCPF(Customer))
                result = CustomerService.EditCustomer(Customer, oldCPF);
            else
                return;
            if (String.IsNullOrEmpty(result))
            {
                Message("Cliente atualizado");
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                Message(result);
            }
        }


        private bool ValidateCPF(Customer customer)
        {
            customer.CPF = CustomerBussines.ExcludeDotsCPF(customer.CPF);
            if (customer.CPF.Length < 11)
            {
                ModelState.AddModelError("CPF Inválido!", "Obrigatório informar um número válido.");
                lblValidateCPF.Text = "CPF Inválido!";
                return false;
            }
            else
                return true;
        }
        private void Message(string result)
        {
            String csname1 = "PopupScript";
            //Queria usar sweetAlert2 mas não consegui.
            if (!IsClientScriptBlockRegistered(csname1))
            {
                String cstext1 = "<script type=\"text/javascript\">" +
                    "alert('"+result+"');</" + "script>";

                RegisterStartupScript(csname1, cstext1);
            }
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