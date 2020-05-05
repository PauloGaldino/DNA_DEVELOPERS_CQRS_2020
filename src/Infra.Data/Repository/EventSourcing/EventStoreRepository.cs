using Domain.Core.Events;
using Infra.Data.Datas.Context;
using Infra.Data.Repository.EventSourcing.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Infra.Data.Repository.EventSourcing
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly EventStoreDbContext _context;

        public EventStoreRepository(EventStoreDbContext context)
        {
            _context = context;
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            return (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToList();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}