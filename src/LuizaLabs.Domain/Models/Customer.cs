using System;
using System.Collections.Generic;

namespace LuizaLabs.Domain.Models
{
    public class Customer 
    {
        public Customer(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Customer() { }

        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public IEnumerable<Favorite> Favorites { get; set; }
    }
}
