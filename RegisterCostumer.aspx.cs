using ManagamentCostumer.Database;
using ManagamentCostumer.WebService;
using System;
using System.Web.UI;
namespace ManagamentCostumer
{
    public partial class RegisterCostumer : Page
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

            CostumerService.VerifyInsertCostumer(costumer);
        }
    }
}