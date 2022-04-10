using ManagamentCustomer.Database;
using ManagamentCustomer.Database.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManagamentCustomer.Service
{
    public class CustomerBussines
    {
        public static Customer VerifyInsertCostumer(Customer custumer)
        {
            Regex rgx = new Regex($@"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/");

            if (rgx.IsMatch(custumer.CPF))
            {
                //validar cpf
            }
            string newCPF = Regex.Replace(custumer.CPF, "[^0-9]", "");
            custumer.CPF = newCPF;
            return custumer;
        }
    }
}
