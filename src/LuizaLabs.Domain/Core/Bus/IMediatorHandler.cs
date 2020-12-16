using LuizaLabs.Domain.Core.Events;
using System.Threading.Tasks;
using LuizaLabs.Domain.Core.Commands;

namespace LuizaLabs.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
