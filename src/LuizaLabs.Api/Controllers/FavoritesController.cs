using LuizaLabs.Application.Interfaces;
using LuizaLabs.Application.ViewModels;
using LuizaLabs.Domain.Core.Bus;
using LuizaLabs.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LuizaLabs.Api.Controllers
{
    public class FavoritesController : ApiController
    {
        private readonly IFavoritesAppService _favoriteAppService;

        public FavoritesController(
            ICustomerAppService customerAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator, 
            IFavoritesAppService 
            favoriteAppService) : base(notifications, mediator)
        {            
            _favoriteAppService = favoriteAppService;
        }

        [HttpPost("add-product/{productid:guid}/{customerid:guid}")]
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

        [HttpPost("remove-product/{productid:guid}/{customerid:guid}")]
        public async Task<IActionResult> Remove([FromBody] RemoveProductViewModel removeProductViewModel)
        {
            await _favoriteAppService.Remove(removeProductViewModel.Id);                            

            return Response();
        }

        [HttpGet("customer-favorite-list/{customerId:guid}")]
        public async Task<IActionResult> Get(Guid customerId)
        {
            return Response(_favoriteAppService.GetByCustomerId(customerId));
        }
    }
}
