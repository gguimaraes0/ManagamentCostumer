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
    public class CustomerService : ICustomer
    {
        public static CustomerService customerService = new CustomerService();

        public CustomerService()
        {
          
        }

        public List<Customer> GetAllCustomers()
        {
            return CustomerDAO.GetCustomers();
        }

        public string InsertCustomer(Customer customer)
        {
            try
            {
                Customer result = CustomerDAO.GetCustomerByCPF(customer.CPF);
                if (result != null)
                {
                    return "Cliente com esse CPF já cadastrado";
                }
                CustomerDAO.InsertCostumer(customer);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EditCustomer(Customer customer, string oldCpf)
        {
            try
            {
                Customer result = CustomerDAO.GetCustomerByCPF(customer.CPF);
                if (result != null)
                {
                    return "Cliente com esse CPF já cadastrado";
                }
                CustomerDAO.EditCostumer(customer, oldCpf);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Customer GetCustomer(string customerCpf)
        {
            try
            {
                customerCpf = CustomerBussines.ExcludeDotsCPF(customerCpf);
                return CustomerDAO.GetCustomerByCPF(customerCpf);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string DeleteCustomer(string cpf)
        {
            try
            {
                cpf = CustomerBussines.ExcludeDotsCPF(cpf);
                CustomerDAO.DeleteCustomer(cpf);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
