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
            Customer costumer = new Customer();
            costumer.CPF = CPF.Text;

            costumer.Sex = Convert.ToChar(DropDownSex.SelectedItem.ToString());

            var situation = DropDownSituation.SelectedItem.Text;
            Enum.TryParse(situation, out CustomerSituations resultsit);
            costumer.CustomerSituations =resultsit;

            var type = DropDownType.SelectedItem.Text;
            Enum.TryParse(type, out CustomerTypes resulttyp);
            costumer.CustomerTypes = resulttyp;

            CustomerService.InsertCustomer(costumer);
            Response.Redirect("~/Home.aspx");

        }
    }
}