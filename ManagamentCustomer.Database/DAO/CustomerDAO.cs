using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagamentCustomer.Database.DAO
{
    public class CustomerDAO
    {
        public static bool InsertCostumer(Customer customer)
        {
            HelperDAO.ExecutaProc("spInsertCustomer", CreateParam(customer));

            return true;
        }

        public static bool EditCostumer(Customer customer, string oldCpf)
        {
            HelperDAO.ExecutaProc("spAlterCustomer", CreateParamUpdate(customer, oldCpf));

            return true;
        }

        protected static SqlParameter[] CreateParamUpdate(Customer customer, string oldCpf)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("CPF", customer.CPF);
            parametros[1] = new SqlParameter("oldCPF", oldCpf);

            parametros[2] = new SqlParameter("CustomerType", Convert.ToInt32(customer.CustomerTypes));
            parametros[3] = new SqlParameter("Sex", customer.Sex);
            parametros[4] = new SqlParameter("CustomerSituation", Convert.ToInt32(customer.CustomerSituations));

            return parametros;
        }


        protected static SqlParameter[] CreateParam(Customer customer)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("CPF", customer.CPF);
            parametros[1] = new SqlParameter("CustomerType", Convert.ToInt32(customer.CustomerTypes));
            parametros[2] = new SqlParameter("Sex", customer.Sex);
            parametros[3] = new SqlParameter("CustomerSituation", Convert.ToInt32(customer.CustomerSituations));

            return parametros;
        }

        protected static SqlParameter[] CreateParamSelect(string customerCpf)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("CPF", customerCpf);
            return parametros;
        }

        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            var result = HelperDAO.ExecutaProcSelect("spListCustomers", null);

            foreach (DataRow dataRow in result.Rows)
                customers.Add(FillModel(dataRow));
            return customers;
        }
        public static Customer GetCustomerByCPF(string customerCpf)
        {
            var result = HelperDAO.ExecutaProcSelect("spQueryCustomer", CreateParamSelect(customerCpf));

            if (result.Rows.Count == 0)
                return null;
            else
            {
                DataRow registro = result.Rows[0];
                return FillModel(registro);
            }

        }
        protected static Customer FillModel(DataRow dataRow)
        {
            Customer U = new Customer();
            U.CPF =  dataRow["CPF"].ToString();

            U.Sex = Convert.ToChar(dataRow["Sex"].ToString());
            U.CustomerTypes = (CustomerTypes)(Convert.ToInt32(dataRow["CustomerType"].ToString()));
            U.CustomerSituations = (CustomerSituations)Convert.ToInt32(dataRow["CustomerSituation"].ToString());


            return U;
        }

        public static void DeleteCustomer(string id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("CPF", id)
            };
            HelperDAO.ExecutaProc("spDeleteCustomer ", p);
        }
    }
}
