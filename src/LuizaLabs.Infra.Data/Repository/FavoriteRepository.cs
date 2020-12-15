using LuizaLabs.Domain.Interfaces;
using LuizaLabs.Domain.Models;
using LuizaLabs.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuizaLabs.Infra.Data.Repository
{
    public class FavoriteRepository : Repository<Favorite>, IFavoritesRepository
    {
        public FavoriteRepository(LuizaLabsContext context)
        : base(context)
        {

        }
        public Task<IEnumerable<Favorite>> GetByCustomerId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Favorite> GetByCustomerProduct(Guid customerId, Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}
