using FluentValidation.Results;
using LuizaLabs.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuizaLabs.Application.Interfaces
{
    public interface IFavoritesAppService : IDisposable
    {
        Task<IEnumerable<FavoriteViewModel>> GetByCustomerId(Guid CustomerId);
        Task Add(AddProductViewModel addProductViewModel);
        Task Remove(Guid id);
    }
}
