using System;
using System.Collections.Generic;
using System.Text;

namespace Fremlæggelse.Model
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = Guid.NewGuid();
        }
    }
}
