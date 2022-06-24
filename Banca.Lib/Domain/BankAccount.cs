using System;
using System.Collections.Generic;
using System.Text;

namespace Banca.Lib.Domain
{
    public class BankAccount
    {
        public int Number { get; }

        public string Pin { get; private set; }

        public DateTime OpenDate { get; }

        public decimal PreviousAmount { get; private set; }
        public decimal Amount { get; private set; }

        public string Iban { get; }

        public BankAccountStatus Status { get; private set; }

        public Customer Customer { get; }
        public IList<Transaction> Transactions { get; }


        /// <summary>
        /// Crea un nuovo conto. 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="pin"></param>
        /// <param name="iban"></param>
        /// <param name="customer"></param>
        public BankAccount(int number, string pin, string iban, Customer customer)
        {
            Number = number;
            Pin = pin;
            Iban = iban;
            Customer = customer;

            Amount = 0;
            PreviousAmount = 0;
            Status = BankAccountStatus.Opened;
            Transactions = new List<Transaction>();
            OpenDate = DateTime.Now;

            customer.BankAccounts.Add(this); 
                    
        }

        public BankAccount(
            int number, 
            string pin, 
            DateTime openDate, 
            decimal previousAmount, 
            decimal amount, 
            string iban, 
            BankAccountStatus status, 
            Customer customer, 
            IList<Transaction> transactions)
        {
            Number = number;
            Pin = pin;
            OpenDate = openDate;
            PreviousAmount = previousAmount;
            Amount = amount;
            Iban = iban;
            Status = status;
            Customer = customer;
            Transactions = transactions;
        }

        public void UpdatePin(string newPin)
        {
            if (string.IsNullOrEmpty(newPin))  //newPin == "" || newPin == null
                throw new ArgumentNullException("Pin vuoto");

            if (newPin.Length != 4)
                throw new ArgumentException("Lunghezza pin non valida");
            Pin = newPin;
        }

        public void BlockBankAccount()
        {
            Status = BankAccountStatus.Blocked;
        }
    }
}
