using LuizaLabs.Domain.Interfaces;
using LuizaLabs.Domain.Models;
using LuizaLabs.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizaLabs.Infra.Data.Repository
{
    public class FavoriteRepository : Repository<Favorite>, IFavoritesRepository
    {
        public FavoriteRepository(LuizaLabsContext context)
        : base(context)
        {

        }
        public async Task<IEnumerable<Favorite>> GetByCustomerId(Guid id)
        {
            return await DbSet
                .AsNoTracking()
                .Where(x => x.CustomerId == id)
                .ToListAsync();
        }

        public async Task<Favorite> GetByCustomerProduct(Guid customerId, Guid productId)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.CustomerId == customerId && x.ProductId == productId);
        }
    }
}
