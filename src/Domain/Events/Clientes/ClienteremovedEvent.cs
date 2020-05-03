using Domain.Core.Events;
using System;

namespace Domain.Events.Clientes
{
    public class ClienteremovedEvent : Event
    {
        public ClienteremovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}