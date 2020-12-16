using System.Collections.Generic;
using System.Security.Claims;

namespace LuizaLabs.Domain.Core.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
