using System;
using System.Collections.Generic;
using System.Text;

namespace Fremlæggelse.Model
{
    public abstract class Entity
    {
        public Guid Id { get; internal set; }
        public string DocumentId()
        {
            return $"{this.GetType().Name}-{Id}";
        }
    }
}
