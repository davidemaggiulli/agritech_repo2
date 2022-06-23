using System;
using System.Collections.Generic;
using System.Text;

namespace Banca.Lib.Domain
{
    public class Customer
    {
        public Customer(int id, string fistName, string lastName, string cf)
        {
            Id = id;
            FirstName = FirstName;
            LastName = lastName;
            CF = cf;
        }
        public int Id { get; }
        public string FirstName { get; }

        public string LastName { get; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public string CF { get; }

        public DateTime Birthdate { get; set; }

        public Gender Gender { get; set; }

        public Address Address { get; set; }

        public IList<BankAccount> BankAccounts { get; set; }
    }
}
