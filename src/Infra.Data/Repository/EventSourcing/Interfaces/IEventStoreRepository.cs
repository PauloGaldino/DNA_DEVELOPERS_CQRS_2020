using Domain.Core.Events;
using System;
using System.Collections.Generic;

namespace Infra.Data.Repository.EventSourcing.Interfaces
{
    public interface IEventStoreRepository : IDisposable
    {
        /// <summary>
        /// Interface dos métodos do EventStore
        /// </summary>
        /// <param name="theEvent"></param>
        
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
