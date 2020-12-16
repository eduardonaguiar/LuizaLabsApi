using System;

namespace LuizaLabs.Application.ViewModels
{
    public class FavoriteViewModel 
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Price { get; private set; }
        public string Image { get; private set; }
        public string Title { get; private set; }
    }
}
