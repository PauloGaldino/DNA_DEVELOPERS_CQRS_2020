using Domain.Core.Bus;
using Domain.Core.Commands;
using Domain.Core.Events;
using Domain.Core.Events.Interfaces;
using MediatR;
using System;
using System.Threading.Tasks;

namespace CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator mediator;
        private readonly IEventStore eventStore;

        public InMemoryBus(IMediator mediator, IEventStore eventStore)
        {
            this.mediator = mediator;
            this.eventStore = eventStore;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                eventStore?.Save(@event);

            return mediator.Publish(@event);
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            throw new NotImplementedException();
        }
    }
}
