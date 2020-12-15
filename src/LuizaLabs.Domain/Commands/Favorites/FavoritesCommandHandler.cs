using FluentValidation.Results;
using LuizaLabs.Domain.Core.Bus;
using LuizaLabs.Domain.Core.CommandHandlers;
using LuizaLabs.Domain.Core.Interfaces;
using LuizaLabs.Domain.Core.Notifications;
using LuizaLabs.Domain.Events.Favorites;
using LuizaLabs.Domain.Interfaces;
using LuizaLabs.Service.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LuizaLabs.Domain.Commands.Favorites
{
    public class FavoritesCommandHandler : CommandHandler,
         IRequestHandler<AddProductCommand, bool>,
         IRequestHandler<RemoveProductCommand, bool>
    {
        private readonly IFavoritesRepository _favoritesRepository;
        private readonly IProductSearchService _productService;
        private readonly IMediatorHandler Bus;

        public FavoritesCommandHandler(ICustomerRepository customerRepository,
                      IUnitOfWork uow,
                      IMediatorHandler bus,
                      INotificationHandler<DomainNotification> notifications, 
                      IFavoritesRepository favoritesRepository,
                      IProductSearchService productService) : base(uow, bus, notifications)
        {
            _favoritesRepository = favoritesRepository;
            _productService = productService;
            _favoritesRepository = favoritesRepository;
            _productService = productService;
        }

        public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(request.ProductId);

            if (product == null)
            {                
                await Bus.RaiseEvent(new DomainNotification(request.MessageType, "Produdo inesistente."));

                return await Task.FromResult(false);
            }
            
            var exists = await _favoritesRepository.GetByCustomerProduct(request.CustomerId, request.ProductId) != null;
            if (exists)
            {                
                await Bus.RaiseEvent(new DomainNotification(request.MessageType, "Produdo já existe na lista de favoritos."));

                return await Task.FromResult(false);
            }

            var favorite = new Models.Favorite(Guid.NewGuid(), request.CustomerId, request.ProductId, product.Price, product.Image, product.Title);

            _favoritesRepository.Add(favorite);

            if (Commit())
            {
                await Bus.RaiseEvent(new AddProductEvent(favorite.CustomerId, favorite.ProductId, favorite.Price, favorite.Image, favorite.Title));
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var favorite = _favoritesRepository.GetById(request.Id);

            if (favorite == null)
            {                

                await Bus.RaiseEvent(new DomainNotification(request.MessageType, "Favorito nao encontrado."));

                return await Task.FromResult(false);
            }
            
            _favoritesRepository.Remove(favorite.Id);


            return await Task.FromResult(true);
        }
    }
}
