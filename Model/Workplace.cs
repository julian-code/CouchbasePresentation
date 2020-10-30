using System;
using System.Collections.Generic;
using System.Text;

namespace Fremlæggelse.Model
{
    public class Workplace : Entity
    {
        public string Name { get; set; }
        public ICollection<Person> Staff { get; set; }
    }
}
