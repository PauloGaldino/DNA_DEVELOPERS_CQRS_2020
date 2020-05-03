using Domain.Events.Clientes;
using Domain.Events.Produtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.EventHandler
{
    public class ProdutoEventHandler :
        INotificationHandler<ProdutoRegisteredEvent>,
        INotificationHandler<ProdutoRemovedEvent>,
        INotificationHandler<ProdutoUpdatedEvent>
    {
   
        public Task Handle(ProdutoRegisteredEvent message, CancellationToken cancellationToken)
        {
            //Envia um e-mail de saudação
            return Task.CompletedTask;
        }

        public Task Handle(ProdutoRemovedEvent message, CancellationToken cancellationToken)
        {
            // Envie alguns e-mails em breve
            return Task.CompletedTask;
        }

        public Task Handle(ProdutoUpdatedEvent message, CancellationToken cancellationToken)
        {
            //Envia algum tipo de e-mail de notificação
            return Task.CompletedTask;
        }
    }
}
