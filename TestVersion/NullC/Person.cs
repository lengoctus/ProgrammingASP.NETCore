using System;
using System.Collections.Generic;
using System.Text;

namespace TestVersion.NullC
{
    class Person
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            MiddleName = null;
            LastName = lastName;
        }

        public Person(string firstName, string middleName, string lastName) : this(firstName, middleName)
        {
            LastName = lastName;
        }
    }
}
