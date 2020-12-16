using LuizaLabs.Domain.Core.Interfaces;
using LuizaLabs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuizaLabs.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}
