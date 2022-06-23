using System;
using System.Collections.Generic;
using System.Text;

namespace Banca.Lib.Domain
{
    public class Customer : Person
    {
        public Customer(int id, string firstName, string lastName, string cf) : base(id, firstName, lastName, cf)
        {
            BankAccounts = new List<BankAccount>();
        }

        public IList<BankAccount> BankAccounts { get; }
    }

}
