using Domain.Commands.Clientes;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using Domain.Events.Clientes;
using Domain.Interfaces;
using Domain.Interfaces.DNA.Domain.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Domain.CommandHandlers
{
    public class ClienteCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewClienteCommand, bool>,
        IRequestHandler<UpdateClienteCommand, bool>,
        IRequestHandler<RemoveClienteCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediatorHandler Bus;

        public ClienteCommandHandler(IClienteRepository clienteRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _clienteRepository = clienteRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var cliente = new Cliente(Guid.NewGuid(), message.Nome, message.Email, message.DataNascimento);

            if (_clienteRepository.GetByEmail(cliente.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "O email do cliente já foi recebido. "));
                return Task.FromResult(false);
            }

            _clienteRepository.Add(cliente);

            if (Commit())
            {
                Bus.RaiseEvent(new ClienteRegisteredEvent(cliente.Id, cliente.Nome, cliente.Email, cliente.DataNascimento));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var cliente = new Cliente(message.Id, message.Nome, message.Email, message.DataNascimento);
            var clienteExixte = _clienteRepository.GetByEmail(cliente.Email);

            if (clienteExixte != null && clienteExixte.Id != cliente.Id)
            {
                if (!clienteExixte.Equals(cliente))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "O email do cliente já foi recebido."));
                    return Task.FromResult(false);
                }
            }

            _clienteRepository.Update(cliente);

            if (Commit())
            {
                Bus.RaiseEvent(new ClienteUpdatedEvent(cliente.Id, cliente.Nome, cliente.Email, cliente.DataNascimento));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _clienteRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new ClienteRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
