using FluentValidation.Results;
using LuizaLabs.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuizaLabs.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        Task Add(AddCustomerViewModel customerViewModel);
        Task<IEnumerable<CustomerViewModel>> GetAll();
        Task<CustomerViewModel> GetById(Guid id);
        Task Update(CustomerViewModel customerViewModel);
        Task Remove(Guid id);
    }
}
