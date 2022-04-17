using ManagamentCustomer.Database;
using ManagamentCustomer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManagamentCustomer
{
    public partial class RegisterCostumer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillFields();
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
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.CPF = CPF.Text;

            customer.Sex = Convert.ToChar(DropDownSex.SelectedItem.ToString());

            var situation = DropDownSituation.SelectedItem.Text;
            Enum.TryParse(situation, out CustomerSituations resultsit);
            customer.CustomerSituations =resultsit;

            var type = DropDownType.SelectedItem.Text;
            Enum.TryParse(type, out CustomerTypes resulttyp);
            customer.CustomerTypes = resulttyp;
            string result = "";
            if (ValidateCPF(customer))
                result = CustomerService.customerService.InsertCustomer(customer);
            else
                return;
            if (String.IsNullOrEmpty(result))
            {
                Message("Cliente adicionado");
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                Message(result);
            }
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
    }
}