using Domain.Events.Clientes;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.EventHandler
{
    public class ClienteEventHandler :
        INotificationHandler<ClienteRegisteredEvent>,
        INotificationHandler<ClienteremovedEvent>,
        INotificationHandler<ClienteUpdatedEvent>
    {
        public Task Handle(ClienteUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Enviar algum email de notificação

            return Task.CompletedTask;
        }

        public Task Handle(ClienteRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Envie um e-mail de saudações
            return Task.CompletedTask;
        }

        public Task Handle(ClienteremovedEvent message, CancellationToken cancellationToken)
        {
            // Envie alguns e-mails em breve

            return Task.CompletedTask;
        }
    }
}
