using FluentValidation.Results;
using LuizaLabs.Domain.Core.Bus;
using LuizaLabs.Domain.Core.CommandHandlers;
using LuizaLabs.Domain.Core.Interfaces;
using LuizaLabs.Domain.Core.Notifications;
using LuizaLabs.Domain.Events;
using LuizaLabs.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LuizaLabs.Domain.Commands.Customer
{
    public class CustomerCommandHandler : CommandHandler,
         IRequestHandler<AddNewCustomerCommand, bool>,
         IRequestHandler<UpdateCustomerCommand, bool>,
         IRequestHandler<RemoveCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler Bus;

        public CustomerCommandHandler(ICustomerRepository customerRepository,
                              IUnitOfWork uow,
                              IMediatorHandler bus,
                              INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _customerRepository = customerRepository;
            Bus = bus;
        }

        public async Task<bool> Handle(AddNewCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);

                return await Task.FromResult(false);
            }

            var customer = new Models.Customer(Guid.NewGuid(), request.Name, request.Email);

            if (_customerRepository.GetByEmail(customer.Email) != null)
            {
                await Bus.RaiseEvent(new DomainNotification(request.MessageType, "Esse endereço de e-mail já foi utilizado."));

                return await Task.FromResult(false);
            }            

            _customerRepository.Add(customer);

            if (Commit())
            {
                await Bus.RaiseEvent(new CustomerAddEvent(customer.Id, customer.Name, customer.Email));
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);

                return await Task.FromResult(false);
            }

            var customer = new Models.Customer(request.Id, request.Name, request.Email);
            var existingCustomer = _customerRepository.GetByEmail(customer.Email);

            if (existingCustomer != null && existingCustomer.Id != customer.Id)
            {
                if (!existingCustomer.Equals(customer))
                {
                    await Bus.RaiseEvent(new DomainNotification(request.MessageType, "Esse endereço de e-mail já foi utilizado."));

                    return await Task.FromResult(false);
                }
            }            

            _customerRepository.Update(customer);

            if (Commit())
            {
                await Bus.RaiseEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email));
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);

                return await Task.FromResult(false);
            }

            var customer = _customerRepository.GetById(request.Id);

            if (customer is null)
            {                
                await Bus.RaiseEvent(new DomainNotification(request.MessageType, "Esse cliente não existe na base de dados."));

                return await Task.FromResult(false);
            }
            
            _customerRepository.Remove(customer.Id);

            if (Commit())
            {
                await Bus.RaiseEvent(new CustomerRemovedEvent(request.Id));
            }

            return await Task.FromResult(true);
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}
