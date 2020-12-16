using LuizaLabs.Domain.Core.Events;
using System;

namespace LuizaLabs.Domain.Events.Favorites
{
    public class RemoveProductEvent : Event
    {
        public RemoveProductEvent(Guid customerId, Guid productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }

        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}
