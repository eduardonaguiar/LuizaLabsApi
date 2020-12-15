﻿using AutoMapper;
using FluentValidation.Results;
using LuizaLabs.Application.Interfaces;
using LuizaLabs.Application.ViewModels;
using LuizaLabs.Domain.Commands.Favorites;
using LuizaLabs.Domain.Core.Bus;
using LuizaLabs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuizaLabs.Application.Services
{
    public class FavoritesAppService : IFavoritesAppService
    {
        private readonly IMapper _mapper;
        private readonly IFavoritesRepository _favoritesRepository;        
        private readonly IMediatorHandler _mediator;        


        public FavoritesAppService(IMapper mapper, IFavoritesRepository favoritesRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _favoritesRepository = favoritesRepository;            
            _mediator = mediator;            
        } 

        public async Task Add(AddProductViewModel addProductViewModel)
        {
            var AddProductCommand = new AddProductCommand(addProductViewModel.CustomerId, addProductViewModel.ProductId);
            await _mediator.SendCommand(AddProductCommand);
        }

        public async Task<IEnumerable<FavoriteViewModel>> GetByCustomerId(Guid customerId)
        {
            return _mapper.Map<IEnumerable<FavoriteViewModel>>(await _favoritesRepository.GetByCustomerId(customerId));
        }

        public async Task Remove(Guid id)
        {
            var removeProductCommand = new RemoveProductCommand(id);
            await _mediator.SendCommand(removeProductCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
