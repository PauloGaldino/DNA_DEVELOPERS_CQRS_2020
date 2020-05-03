using Domain.Core.Commands;
using System;

namespace Domain.Commands.Produtos
{
    public abstract class ProdutoCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Descricao { get; protected set; }
        public decimal Preco { get; protected set; }
        public string Lote { get; protected set; }
        public DateTime DataFabricacao { get; protected set; }
        public DateTime DataValidade { get; protected set; }
    }
}
