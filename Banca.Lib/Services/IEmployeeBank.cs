using Banca.Lib.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banca.Lib.Services
{
    public interface IEmployeeBank
    {
        /// <summary>
        /// Crea un nuovo cliente a cui associa un nuovo conto corrente
        /// </summary>
        /// <param name="fname">Nome cliente</param>
        /// <param name="lname">Cognome cliente</param>
        /// <param name="cf">Codice Fiscale Cliente</param>
        /// <param name="iban">Iban conto</param>
        /// <returns></returns>
        Customer CreateCustomerWithBankAccount(string fname, string lname, string cf, string iban);

        BankAccount CreteBankAccountForExistingCustomer(Customer existingCustomer, string newBankAccountIban);

        Customer SearchCustomer(string fname, string lname);

        /// <summary>
        /// Cerca il cliente dato un ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Customer GetCustomerById(int customerId);

        string GetBankAccountDetails(int number);

        BankAccount GetBankAccountByNumber(int number);


    }
}
