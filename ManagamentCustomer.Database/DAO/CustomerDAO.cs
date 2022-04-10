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
            HelperDAO.ExecutaProc("spInsertCustomer", CriaParametros(customer));

            return true;
        }
        protected static SqlParameter[] CriaParametros(Customer customer)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("CPF", customer.CPF);
            parametros[1] = new SqlParameter("CustomerType", Convert.ToInt32(customer.CustomerTypes));
            parametros[2] = new SqlParameter("Sex", customer.Sex);
            parametros[3] = new SqlParameter("CustomerSituation", Convert.ToInt32(customer.CustomerSituations));

            return parametros;
        }

        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            var result = HelperDAO.ExecutaProcSelect("spListCustomers", null);

            foreach (DataRow dataRow in result.Rows)
                customers.Add(MontaModel(dataRow));
            return customers;
        }

        protected static Customer MontaModel(DataRow dataRow)
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
