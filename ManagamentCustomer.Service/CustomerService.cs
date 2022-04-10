﻿using ManagamentCustomer.Database;
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
    public class CustomerService/* : ICustomer*/
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


        public static bool DeleteCustomer(string cpf)
        {
            try
            {//mensagem de confirmação
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