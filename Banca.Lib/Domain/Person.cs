using System;
using System.Collections.Generic;
using System.Text;

namespace Banca.Lib.Domain
{
    public class Person
    {
        public Person(int id, string firstName, string lastName, string cf)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CF = cf;
        }
        public int Id { get; }
        public string FirstName { get; }

        public string LastName { get; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public string CF { get; }

        public DateTime? Birthdate { get; set; }

        public int Age
        {
            get
            {
                if (Birthdate.HasValue)  //BirthDate != null
                    return (int)(DateTime.Now - Birthdate.Value).TotalDays / 365;
                return 0;
            }
        }

        public Gender Gender { get; set; }
        public Address Address { get; set; }
    }
}
