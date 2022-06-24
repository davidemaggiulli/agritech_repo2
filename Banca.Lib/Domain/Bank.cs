using System;
using System.Collections.Generic;
using System.Text;

namespace Banca.Lib.Domain
{
    public class Bank
    {
        public Bank()
        {
            Customers = new List<Customer>();
            Employees = new List<Employee>();   
            BankAccounts = new List<BankAccount>();
        }
        public IList<Customer> Customers { get; }
        public IList<Employee> Employees { get; }
        public IList<BankAccount> BankAccounts { get; }
    }
}
