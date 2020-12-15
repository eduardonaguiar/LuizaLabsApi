using LuizaLabs.Domain.Interfaces;
using LuizaLabs.Domain.Models;
using LuizaLabs.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LuizaLabs.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LuizaLabsContext context)
            : base(context)
        {

        }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
