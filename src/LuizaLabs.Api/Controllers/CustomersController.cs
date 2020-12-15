using LuizaLabs.Application.Interfaces;
using LuizaLabs.Application.ViewModels;
using LuizaLabs.Domain.Core.Bus;
using LuizaLabs.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuizaLabs.Api.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(
            ICustomerAppService customerAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _customerAppService = customerAppService;
        }


        [HttpGet("customer")]
        public async Task<IEnumerable<CustomerViewModel>> Get()
        {
            return await _customerAppService.GetAll();
        }

        [HttpGet("customer/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var customerViewModel = _customerAppService.GetById(id);

            return Response(customerViewModel);
        }


        [HttpPost("customer")]
        public async Task<IActionResult> Post([FromBody] CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            await _customerAppService.Add(customerViewModel);

            return Response(customerViewModel);
        }


        [HttpPut("customer")]
        public async Task<IActionResult> Put([FromBody] CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            await _customerAppService.Update(customerViewModel);

            return Response(customerViewModel);
        }


        [HttpDelete("customer")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _customerAppService.Remove(id);

            return Response();
        }
    }
}
