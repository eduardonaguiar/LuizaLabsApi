using System;

namespace LuizaLabs.Service.Models
{
    public class ProductServiceModel
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
    }
}
