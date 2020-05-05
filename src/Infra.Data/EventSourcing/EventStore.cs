﻿using Domain.Core.Events;
using Domain.Core.Events.Interfaces;
using Domain.Interfaces;
using Infra.Data.Repository.EventSourcing.Interfaces;
using Newtonsoft.Json;

namespace Infra.Data.EventSourcing
{
    /// <summary>
    /// Classe para registrar os evento de pesquisa
    /// </summary>
    public class EventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IUser _user;

        public EventStore(IEventStoreRepository eventStoreRepository, IUser user)
        {
           _eventStoreRepository = eventStoreRepository;
            _user = user;
        }
        
        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                _user.Nome);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
