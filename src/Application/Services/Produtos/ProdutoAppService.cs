using Application.EventSourcedNomalizer.Cliente;
using Application.EventSourcedNomalizer.Produtos;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Commands.Produtos;
using Domain.Interfaces;
using Infra.Data.Repository.EventSourcing.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Application.Services.Produtos
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediator Bus;

        public ProdutoAppService(IMapper mapper, IProdutoRepository produtoRepository, IEventStoreRepository eventStoreRepository, IMediator bus)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;
        }

       

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            return _produtoRepository.GetAll().ProjectTo<ProdutoViewModel>(_mapper.ConfigurationProvider);
        }

        public IList<ProdutoHistoryData> GetAllHistory(Guid id)
        {
            return ProdutoHistory.ToJavaScriptProdutoHistory(_eventStoreRepository.All(id));
        }

        public ProdutoViewModel GetById(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(_produtoRepository.GetById(id));
        }

        public void Register(ProdutoViewModel produtoViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProdutoCommand>(produtoViewModel);
            Bus.Send(registerCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = _mapper.Map<RemoveProdutoCommand>(id);
            Bus.Send(removeCommand);
        }

        public void Update(ProdutoViewModel produtoViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProdutoCommand>(produtoViewModel);
            Bus.Send(updateCommand);
        } 

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
