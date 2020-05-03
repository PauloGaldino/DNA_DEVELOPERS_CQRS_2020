using Domain.Core.Events;
using System;

namespace Domain.Events.Produtos
{
    public class ProdutoRegisteredEvent : Event
    {
        public ProdutoRegisteredEvent(Guid id, string descricao, decimal preco, string lote, DateTime dataFabricacao,DateTime dataValidade )
        {
            Id = id;
            Descricao = descricao;
            Preco = preco;
            Lote = lote;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
        }
        public Guid Id { get; set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public string Lote { get; private set; }
        public DateTime DataFabricacao { get; private set; }
        public DateTime DataValidade { get; private set; }

    }
}
