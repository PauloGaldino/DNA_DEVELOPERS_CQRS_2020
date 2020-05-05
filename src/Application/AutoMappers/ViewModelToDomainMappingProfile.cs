using Application.ViewModels;
using AutoMapper;
using Domain.Commands.Clientes;
using Domain.Commands.Produtos;

namespace Application.AutoMappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //Cliente
            CreateMap<ClienteViewModel, RegisterNewClienteCommand>()
                    .ConstructUsing(c => new RegisterNewClienteCommand(c.Nome, c.Email, c.DataNascimento));
            CreateMap<ClienteViewModel, UpdateClienteCommand>()
                .ConstructUsing(c => new UpdateClienteCommand(c.Id, c.Nome, c.Email, c.DataNascimento));

            //Produto
            CreateMap<ProdutoViewModel, RegisterNewProdutoCommand>()
                .ConstructUsing(p => new RegisterNewProdutoCommand(p.Descricao, p.Preco, p.Lote, p.DataFabricacao, p.DataValidade));
            CreateMap<ProdutoViewModel, UpdateProdutoCommand>()
                .ConstructUsing(p => new UpdateProdutoCommand(p.Id, p.Descricao, p.Preco, p.Lote, p.DataFabricacao, p.DataValidade));
        }
    }
}
