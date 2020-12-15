using LuizaLabs.Domain.Core.Commands;
using System;

namespace LuizaLabs.Domain.Commands.Favorites
{
    public class FavoritesCommand : Command
    {
        public Guid CustomerId { get; protected set; }
        public Guid ProductId { get; protected set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
