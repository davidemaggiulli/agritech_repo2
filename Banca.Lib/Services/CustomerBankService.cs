using Banca.Lib.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banca.Lib.Services
{
    public class CustomerBankService : ICustomerBank
    {
        private Bank bank;
        public CustomerBankService()
        {
            bank = new Bank();
        }

        public CustomerBankService(Bank bank)
        {
            this.bank = bank;
        }
    }
}
