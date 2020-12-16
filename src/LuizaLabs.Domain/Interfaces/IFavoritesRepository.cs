using LuizaLabs.Domain.Core.Interfaces;
using LuizaLabs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuizaLabs.Domain.Interfaces
{
    public interface IFavoritesRepository : IRepository<Favorite>
    {
        Task<IEnumerable<Favorite>> GetByCustomerId(Guid id);        

        Task<Favorite> GetByCustomerProduct(Guid customerId, Guid productId);
    }
}
