using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LuizaLabs.Domain.Events
{
    public class CustomerEventHandler :
        INotificationHandler<CustomerAddEvent>,
        INotificationHandler<CustomerUpdatedEvent>,
        INotificationHandler<CustomerRemovedEvent>
    {
        public Task Handle(CustomerUpdatedEvent message, CancellationToken cancellationToken)
        {
            
            return Task.CompletedTask;
        }

        public Task Handle(CustomerAddEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CustomerRemovedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
