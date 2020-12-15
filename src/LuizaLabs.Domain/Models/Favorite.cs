using System;

namespace LuizaLabs.Domain.Models
{
    public class Favorite 
    {
        public Favorite(Guid id, Guid customerId, Guid productId, decimal price, string image, string title)
        {
            Id = id;
            CustomerId = customerId;
            ProductId = productId;
            Price = price;
            Image = image;
            Title = title;
        }

        public Favorite() { }

        public Guid Id { get; set; }
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public Guid ProductId { get; private set; }
        public decimal Price { get; private set; }
        public string Image { get; private set; }
        public string Title { get; private set; }
    }
}
