using Domain.Core.Events;
using System;

namespace Domain.Events.Produtos
{
    public class ProdutoRemovedEvent : Event
    {
        public ProdutoRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId= id;
        }
        public Guid Id { get; set; }
    }
}
