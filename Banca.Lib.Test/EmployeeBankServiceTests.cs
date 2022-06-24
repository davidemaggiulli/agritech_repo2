using Banca.Lib.Domain;
using Banca.Lib.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Banca.Lib.Test
{
    public class EmployeeBankServiceTests
    {
        [Fact]
        public void CreateOneCustomerWithBankAccountTest()
        {
            IEmployeeBank service = new EmployeeBankService();

            Customer customer = service.CreateCustomerWithBankAccount("Davide", "Maggiulli", "MGGDVD87H27E815Y", "ITXXXX1223232");


            Assert.NotNull(customer);
            Assert.Equal(1, customer.Id);
            Assert.Equal(1, customer.BankAccounts.Count);
            Assert.Equal(1, customer.BankAccounts[0].Number);
            Assert.Equal("ITXXXX1223232", customer.BankAccounts[0].Iban);
            Assert.NotEmpty(customer.BankAccounts[0].Pin);
            Assert.Equal(4, customer.BankAccounts[0].Pin.Length);
        }

        [Fact]
        public void CreateTwoCustomerWithBankAccountTest()
        {
            IEmployeeBank service = new EmployeeBankService();

            Customer customer1 = service.CreateCustomerWithBankAccount("Davide", "Maggiulli", "MGGDVD87H27E815Y", "ITXXXX1223232");
            Customer customer2 = service.CreateCustomerWithBankAccount("Elena", "Ricci", "ELNRCCsffdfd", "ITYYYYq12131");

            Assert.NotNull(customer2);
            Assert.Equal(2, customer2.Id);
            Assert.Equal(1, customer2.BankAccounts.Count);
            Assert.Equal(2, customer2.BankAccounts[0].Number);
            Assert.Equal("ITYYYYq12131", customer2.BankAccounts[0].Iban);
            Assert.NotEmpty(customer2.BankAccounts[0].Pin);
            Assert.Equal(4, customer2.BankAccounts[0].Pin.Length);
            Assert.NotEqual(customer1.BankAccounts[0].Pin, customer2.BankAccounts[0].Pin);
        }

        [Fact]
        public void CreateAccountFroExistingCustomerTest()
        {

        }

        [Fact]
        public void SearchCustomerTest()
        {
            IEmployeeBank service = new EmployeeBankService();

            Customer customer1 = service.CreateCustomerWithBankAccount("Davide", "Maggiulli", "MGGDVD87H27E815Y", "ITXXXX1223232");
            Customer customer2 = service.CreateCustomerWithBankAccount("Elena", "Ricci", "ELNRCCsffdfd", "ITYYYYq12131");


        }
    }
}
