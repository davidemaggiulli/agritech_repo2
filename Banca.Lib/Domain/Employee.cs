using System;
using System.Collections.Generic;
using System.Text;

namespace Banca.Lib.Domain
{
    public class Employee : Person
    {
        public Employee(int id, string firstName, string lastName, string cf, string username, string pwd) : base(id, firstName, lastName, cf)
        {
            Username = username;
            Password = pwd;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
