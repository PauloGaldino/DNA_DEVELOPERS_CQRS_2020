using Application.EventSourcedNomalizer.Cliente;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Commands.Clientes;
using Domain.Core.Bus;
using Domain.Events.Clientes;
using Domain.Interfaces;
using Infra.Data.Repository.EventSourcing.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Services.Clientes
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public ClienteAppService(IMapper mapper, IClienteRepository clienteRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler bus)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;


        }

        public IEnumerable<ClienteViewModel> GetAll()
        {
            return _clienteRepository.GetAll().ProjectTo<ClienteViewModel>(_mapper.ConfigurationProvider);
        }


        public ClienteViewModel GetById(Guid id)
        {

            return _mapper.Map<ClienteViewModel>(_clienteRepository.GetById(id));
        }

        public void Register(ClienteViewModel clienteViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewClienteCommand>(clienteViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveClienteCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(ClienteViewModel clienteViewModel)
        {
            var updateCommand = _mapper.Map<UpdateClienteCommand>(clienteViewModel);
            Bus.SendCommand(updateCommand);
        }
        public IList<ClienteHistoryData> GetAllHistory(Guid id)
        {
            return ClienteHistory.ToJavaScriptClienteHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
