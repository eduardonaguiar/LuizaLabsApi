using LuizaLabs.Service.Models;
using System;
using System.Threading.Tasks;

namespace LuizaLabs.Service.Interfaces
{
    public interface IProductSearchService
    {
        Task<ProductServiceModel> GetProductByIdAsync(Guid id);
    }
}
