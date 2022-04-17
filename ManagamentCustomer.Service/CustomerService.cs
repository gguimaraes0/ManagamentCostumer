using ManagamentCustomer.Database;
using ManagamentCustomer.Database.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace ManagamentCustomer.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CustomerService
    {
        public static List<Customer> GetAllCustomers()
        {
            return CustomerDAO.GetCustomers();
        }

        public static bool InsertCustomer(Customer customer)
        {
            try
            {
                customer = CustomerBussines.VerifyInsertCostumer(customer);
                CustomerDAO.InsertCostumer(customer);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool EditCustomer(Customer customer, string oldCpf)
        {
            try
            {
                CustomerDAO.EditCostumer(customer, oldCpf);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Customer GetCustomer(string customerCpf)
        {
            try
            {
                return CustomerDAO.GetCustomerByCPF(customerCpf);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool DeleteCustomer(string cpf)
        {
            try
            {//mensagem de confirmação
                cpf = CustomerBussines.ExcludeDotsCPF(cpf);
                CustomerDAO.DeleteCustomer(cpf);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
