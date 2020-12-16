using System;

namespace LuizaLabs.Application.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
    }
}