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
            custumer.CPF = ExcludeDotsCPF(custumer.CPF);
            return custumer;
        }

        public static string ExcludeDotsCPF(string cpf)
        {
            string newCPF = Regex.Replace(cpf, "[^0-9]", "");
            cpf = newCPF;
            return cpf;
        }
    }
}
