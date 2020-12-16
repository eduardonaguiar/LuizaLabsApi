using LuizaLabs.Application.Interfaces;
using LuizaLabs.Application.ViewModels;
using LuizaLabs.Domain.Core.Bus;
using LuizaLabs.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LuizaLabs.Api.Controllers
{
    public class FavoritesController : ApiController
    {
        private readonly IFavoritesAppService _favoriteAppService;

        public FavoritesController(            
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator, 
            IFavoritesAppService 
            favoriteAppService) : base(notifications, mediator)
        {            
            _favoriteAppService = favoriteAppService;
        }

        [HttpPost]
        [Authorize]
        [Route("customer-favorite-add")]
        public async Task<IActionResult> Add([FromBody] AddProductViewModel addProductViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(addProductViewModel);
            }

            await _favoriteAppService.Add(addProductViewModel);
            
            return Response(addProductViewModel);
        }

        [HttpDelete]
        [Authorize]
        [Route("customer-favorite-remove")]
        public async Task<IActionResult> Remove([FromBody] RemoveProductViewModel removeProductViewModel)
        {
            await _favoriteAppService.Remove(removeProductViewModel.Id);

            return Response();
        }

        [HttpGet]
        [Authorize]
        [Route("customer-favorite-list/{customerId:guid}")]
        public async Task<IActionResult> Get(Guid customerId)
        {
            return Response(_favoriteAppService.GetByCustomerId(customerId));
        }
    }
}
