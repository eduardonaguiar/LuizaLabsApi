using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LuizaLabs.Domain.Events.Favorites
{
    public class FavoritesEventHandler :
        INotificationHandler<AddProductEvent>,
        INotificationHandler<RemoveProductEvent>
    {
        public Task Handle(AddProductEvent notification, CancellationToken cancellationToken)
        {
            
            return Task.CompletedTask;
        }

        public Task Handle(RemoveProductEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
