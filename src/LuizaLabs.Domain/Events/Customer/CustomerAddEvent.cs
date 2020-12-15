using LuizaLabs.Domain.Core.Events;
using System;

namespace LuizaLabs.Domain.Events
{
    public class CustomerAddEvent : Event
    {
        public CustomerAddEvent(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;            
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }
    }
}
