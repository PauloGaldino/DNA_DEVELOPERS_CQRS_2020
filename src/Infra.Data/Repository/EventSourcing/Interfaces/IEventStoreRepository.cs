using Domain.Core.Events;
using System;
using System.Collections.Generic;

namespace Infra.Data.Repository.EventSourcing.Interfaces
{
    /// <summary>
    /// Interface dos métodos do EventStore
    /// </summary>
    /// <param name="theEvent"></param>
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
