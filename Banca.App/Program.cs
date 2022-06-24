using Banca.Lib.Domain;
using System;
using System.Collections.Generic;

namespace Banca.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Customer customer = new Customer(1, "Davide", "Maggiulli", "MGGDVD87H27E815Y");

            customer.Birthdate = new DateTime(1987, 6, 27);


            Employee employee = new Employee(1, "Martina", "Nonmiricordo", "GFGFGFGFGF", "martina.bho", "123456");
            employee.Gender = Gender.Female;
            employee.Birthdate = new DateTime(1996, 10, 14);
            employee.Phone = "1234534232";

            employee.Username = "martina.bettoni";

            BankAccount bankAccount = new BankAccount(1, "1234", "ITXXXXXXDSDSDS000", customer);
            



        }
    }
}
