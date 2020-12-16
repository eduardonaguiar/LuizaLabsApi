using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LuizaLabs.Domain.Core.Events;

namespace LuizaLabs.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository
    {
        void Store(StoredEvent theEvent);
        Task<IList<StoredEvent>> All(Guid aggregateId);
    }
}
