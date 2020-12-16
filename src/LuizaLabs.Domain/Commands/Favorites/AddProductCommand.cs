using System;

namespace LuizaLabs.Domain.Commands.Favorites
{
    public class AddProductCommand : FavoritesCommand
    {
        public AddProductCommand(Guid productId, Guid custommerId)
        {
            ProductId = productId;
            CustomerId = custommerId;
        }
    }
}
