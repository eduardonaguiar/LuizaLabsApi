using AutoMapper;
using FluentValidation.Results;
using LuizaLabs.Application.Interfaces;
using LuizaLabs.Application.ViewModels;
using LuizaLabs.Domain.Commands.Customer;
using LuizaLabs.Domain.Core.Bus;
using LuizaLabs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuizaLabs.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;        
        private readonly IMediatorHandler _mediator;

        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository customerRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(_customerRepository.GetAll());
        }

        public async Task<CustomerViewModel> GetById(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));
        }

        public async Task Add(AddCustomerViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<AddNewCustomerCommand>(customerViewModel);
            await _mediator.SendCommand(registerCommand);
        }

        public async Task Update(CustomerViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            await _mediator.SendCommand(updateCommand);
        }

        public async Task Remove(Guid id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            await _mediator.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
