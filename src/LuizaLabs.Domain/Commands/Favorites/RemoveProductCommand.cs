using LuizaLabs.Domain.Core.Commands;
using System;

namespace LuizaLabs.Domain.Commands.Favorites
{
    public class RemoveProductCommand : Command
    {
        public RemoveProductCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
