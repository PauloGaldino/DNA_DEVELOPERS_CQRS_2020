using Domain.Core.Events;
using System;

namespace Domain.Events.Clientes
{
    public class ClienteRemovedEvent : Event
    {
        public ClienteRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}