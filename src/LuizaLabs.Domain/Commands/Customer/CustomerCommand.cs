using LuizaLabs.Domain.Core.Commands;
using System;

namespace LuizaLabs.Domain.Commands
{
    public class CustomerCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
