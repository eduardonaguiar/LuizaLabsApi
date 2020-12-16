using LuizaLabs.Domain.Core.Events;
using System;

namespace LuizaLabs.Domain.Events.Favorites
{
    public class AddProductEvent : Event
    {
        public AddProductEvent(Guid customerId, Guid productId, decimal price, string image, string title)
        {
            CustomerId = customerId;
            ProductId = productId;
            Price = price;
            Image = image;
            Title = title;
        }

        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
    }
}
