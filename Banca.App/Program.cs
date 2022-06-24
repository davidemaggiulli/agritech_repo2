using Banca.Lib.Domain;
using Banca.Lib.Services;
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

            Bank bank = new Bank();
            bank.Customers.Add(customer);
            bank.Employees.Add(employee);
            bank.BankAccounts.Add(bankAccount);

            IEmployeeBank service = new EmployeeBankService(bank);
            ICustomerBank custService = new CustomerBankService(bank);
            var ba = service.CreateCustomerWithBankAccount("Filippo", "Del Porto", "MfsdfsGD87H27E815Y", "IT12121");
            //Console.WriteLine(service.GetBankAccountDetails(1));
            //Console.WriteLine(service.GetBankAccountDetails(2));
            //Console.WriteLine(service.GetBankAccountDetails(3));

            string scelta = "";
            
            do
            {
                PrintMenu();
                Console.WriteLine("Cosa vuoi fare?");
                scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        string fname = GetStringFromConsole("Inserire Nome: ", true);
                        string lname = GetStringFromConsole("Inserire Cognome: ", true);
                        string iban = GetStringFromConsole("Inserire Iban: ", true);
                        string cf = GetStringFromConsole("Inserire Codice Fiscale: ", true);

                        var c = service.CreateCustomerWithBankAccount(fname, lname, iban, cf);
                        if(c != null)
                        {
                            Console.WriteLine($"Cliente creato correttamente: {c.Id}");
                            Console.WriteLine($"Conto creato correttamente: {c.BankAccounts[0].Number}");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Crea conto su cliente esistente");
                        int customerId = GetNaturalFromConsole("Inserire numero cliente: ");
                        var cust = service.GetCustomerById(customerId);
                        if(cust == null)
                        {
                            Console.WriteLine($"Cliente {customerId} non trovato.");
                        } else
                        {
                            string iban1 = GetStringFromConsole("Inserire iban: ");
                            var b = service.CreteBankAccountForExistingCustomer(cust, iban1);
                            if (b != null)
                                Console.WriteLine($"Conto creato correttamente. Numero conto: {b.Number}");
                        }
                        break;
                    case "3":
                        int bankAccountNumber = GetNaturalFromConsole("Inserire numero conto: ");
                        string details = service.GetBankAccountDetails(bankAccountNumber);
                        Console.WriteLine(details);
                        break;
                    case "4":
                        break;
                    case "Q":
                        Console.WriteLine("** Arrivederci **");
                        break;
                    case "H":
                        PrintMenu();
                        break;
                    default:
                        Console.WriteLine($"Scelta '{scelta}' non valida.");
                        break;
                }
                
            } while (scelta != "Q");

            Console.ReadLine();

        }

        private static void PrintMenu()
        {
            Console.WriteLine(" *** Bank ***");
            Console.WriteLine("1 - Inserire Cliente (e conto)");
            Console.WriteLine("2 - Crea conto su cliente");
            Console.WriteLine("3 - Dettagli conto");

            Console.WriteLine("--------------------");
            Console.WriteLine("4 - Preleva dal conto");


            Console.WriteLine("H - Help");
            Console.WriteLine("Q - Esci");
            Console.WriteLine(" *** *** ***");
        }

        private static string GetStringFromConsole(string msg, bool checkIfEmpty = false )
        {
            string s = "";
            bool continueLoop = true;
            do
            {
                Console.Write(msg);
                s = Console.ReadLine();
                if (checkIfEmpty && string.IsNullOrEmpty(s))
                    continueLoop = true;
                else
                    continueLoop = false;
            } while (continueLoop);
            return s;
        }

        private static int GetNaturalFromConsole(string msg)
        {
            int n = 0;
            string s = "";
            do
            {
                Console.Write(msg);
                s = Console.ReadLine();
            } while (!int.TryParse(s, out n) && n <= 0);
            return n;
        }
    }
}
