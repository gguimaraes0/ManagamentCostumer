using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagamentCustomer.Database
{
    public class Customer
    {
        public string CPF { get; set; }
        public CustomerTypes CustomerTypes { get; set; }
        public CustomerSituations CustomerSituations { get; set; }
        public char Sex { get; set; }

        //public override string ToString()
        //{
        //    return ToString();
        //}
    }
}
