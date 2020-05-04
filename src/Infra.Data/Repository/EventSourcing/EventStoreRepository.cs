using Domain.Core.Events;
using Domain.Core.Events.Interfaces;
using Domain.Interfaces;
using Infra.Data.Repository.EventSourcing.Interfaces;
using Newtonsoft.Json;

namespace Infra.Data.Repository.EventSourcing
{
    public class EventStore : IEventStore
    {
        private readonly IEventStoreRepository eventStoreRepository;
        private readonly IUser user;
        public void Save<T>(T theEvent) where T : Event
        {

            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                user.Nome);

            eventStoreRepository.Store(storedEvent);
        }
    }
}
