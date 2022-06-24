using Banca.Lib.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banca.Lib.Services
{
    public class EmployeeBankService : IEmployeeBank
    {
        private Bank bank;
        public EmployeeBankService()
        {
            bank = new Bank();
        }
        public EmployeeBankService(Bank bank)
        {
            this.bank = bank;
        }
        public Customer CreateCustomerWithBankAccount(string fname, string lname, string cf, string iban)
        {
            string pin = GeneratePin();
            int number = GetMaxBankAccountNumber();

            int customerId = 0;
            foreach(var c in bank.Customers)
                if(c.Id > customerId)
                    customerId = c.Id;

            Customer customer = new Customer(customerId + 1, fname, lname, cf);
            BankAccount bankAccount = new BankAccount(number + 1, pin, iban, customer);
            bank.Customers.Add(customer);
            bank.BankAccounts.Add(bankAccount);

            return customer;
        }

        public BankAccount CreteBankAccountForExistingCustomer(Customer existingCustomer, string newBankAccountIban)
        {
            if (existingCustomer == null)
                throw new ArgumentNullException(nameof(existingCustomer), "Il cliente non è stato impostato");

            int number = GetMaxBankAccountNumber();

            BankAccount ba = new BankAccount(number + 1, GeneratePin(), newBankAccountIban, existingCustomer);
            bank.BankAccounts.Add(ba);
            return ba;
        }

        public string GetBankAccountDetails(int number)
        {
            //TODO RIVEDERE (String immutabili)
            var bankAccount = GetBankAccountByNumber(number);
            if (bankAccount == null)
                return $"Conto '{number}' non trovato";
            //else sottinteso
            string s = "";
            s = s + $"Numero Conto:{bankAccount.Number}\n";
            s = s + $"Saldo: {bankAccount.Amount}\n";
            s += $"Iban: {bankAccount.Iban}\n";
            s += $"Stato: {bankAccount.Status}\n";

            s += "-------------------\n";

            s += $"Cliente: {bankAccount.Customer.FirstName} {bankAccount.Customer.LastName} ({bankAccount.Customer.Email})\n";

            s += "-------------------\n";
            s += "Operazioni\n";
            foreach(var t in bankAccount.Transactions)
            {
                s += $"{t.Id}\t{t.Amount}\t{t.Date}\t{t.Description}";
            }

            return s;

        }

        public Customer GetCustomerById(int customerId)
        {
            foreach (var c in bank.Customers)
                if (c.Id == customerId)
                    return c;
            return null;
        }

        public Customer SearchCustomer(string fname, string lname)
        {
            foreach (var c in bank.Customers)
                if (c.FirstName.Equals(fname, StringComparison.InvariantCultureIgnoreCase) && c.LastName.Equals(lname, StringComparison.InvariantCultureIgnoreCase))
                    return c;
            return null;
        }

        public BankAccount GetBankAccountByNumber(int number)
        {
            foreach (var ba in bank.BankAccounts)
                if (ba.Number == number)
                    return ba;
            return null;
        }

        private string GeneratePin()
        {
            Random random = new Random();
            string pin = $"{random.Next(0, 10)}{random.Next(0, 10)}{random.Next(0, 10)}{random.Next(0, 10)}";
            return pin;
        }

        private int GetMaxBankAccountNumber()
        {
            int number = 0;
            //TODO RIVEDERE CON LINQ
            foreach (BankAccount c in bank.BankAccounts)
            {
                if (c.Number > number)
                    number = c.Number;
            }
            return number;
        }


    }
}
