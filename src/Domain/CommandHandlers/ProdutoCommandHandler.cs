using Domain.Commands.Produtos;
using Domain.Core.Bus;
using Domain.Core.Commands;
using Domain.Core.Events;
using Domain.Core.Notifications;
using Domain.Events.Produtos;
using Domain.Interfaces;
using Domain.Interfaces.DNA.Domain.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.CommandHandlers
{
    public class ProdutoCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProdutoCommand, bool>,
        IRequestHandler<RemoveProdutoCommand, bool>,
        IRequestHandler<UpdateProdutoCommand, bool>

    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatorHandler Bus;

        public ProdutoCommandHandler(IProdutoRepository produtoRepository, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _produtoRepository = produtoRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewProdutoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }
            var produto = new Produto(Guid.NewGuid(), message.Descricao, message.Preco, message.Lote, message.DataFabricacao, message.DataValidade);

            if (_produtoRepository.GetById(produto.Id) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Este produto já exixte"));
                return Task.FromResult(false);
            }

            _produtoRepository.Add(produto);
            if (Commit())
            {
                Bus.RaiseEvent(new ProdutoRegisteredEvent(produto.Id, produto.Descricao, produto.Preco, produto.Lote, produto.DataFabricacao, produto.DataValidade));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveProdutoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _produtoRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new ProdutoRemovedEvent(message.Id));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateProdutoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var produto = new Produto(Guid.NewGuid(), message.Descricao, message.Preco, message.Lote, message.DataFabricacao, message.DataValidade);
            var produtoExiste = _produtoRepository.GetById(produto.Id);

            if (produtoExiste != null && produtoExiste.Id == produto.Id)
            {
                if (produtoExiste.Equals(produto))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "O produto já foi atualizado"));
                    return Task.FromResult(false);
                }
            }

            _produtoRepository.Update(produto);
            if (Commit())
            {
                Bus.RaiseEvent(new ProdutoUpdatedEvent(Guid.NewGuid(), message.Descricao, message.Preco, message.Lote, message.DataFabricacao, message.DataValidade));
            }

            return Task.FromResult(true);
        }
    }
}
