using ManagamentCustomer.Database;
using ManagamentCustomer.Service;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

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
            var id = ((System.Web.UI.WebControls.Button)sender).CommandArgument.ToString();
            if (id == null)
                return;
            // Queria usar o sweetAlert2 porém também não consegui.
            DialogResult dialogResult = MessageBox.Show("Deseja Realmente excluir esse cliente ?", "Atenção", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                CustomerService.DeleteCustomer(id);
                Message("Cliente Excluído");
                Response.Redirect("~/Home.aspx");
            }
            else
                Message("Cliente Não Excluído");
        }
        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            var id = ((System.Web.UI.WebControls.Button)sender).CommandArgument.ToString();
            if (id == null)
                return;
            Response.Redirect("~/EditRegister.aspx?cpf="+ id);
        }

        protected void SearchById_Click(object sender, EventArgs e)
        {
            _Customers.Clear();
            string cpf = inputCPF.Text;          
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

        private void Message(string result)
        {
            String csname1 = "PopupScript";
            //Queria usar sweetAlert2 mas não consegui.
            if (!IsClientScriptBlockRegistered(csname1))
            {
                String cstext1 = "<script type=\"text/javascript\">" +
                    "swal.fire('"+result+"');</" + "script>";

                RegisterStartupScript(csname1, cstext1);
            }
        }
    }
}