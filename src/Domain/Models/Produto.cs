using Domain.Core.Models;
using System;

namespace Domain.Models
{
    public class Produto : Entity
    {
        public Produto(Guid id, string descricao, decimal preco, string lote, DateTime dataFabricacao,DateTime dataValidade)
        {
            Id = id;
            Descricao = descricao;
            Preco = preco;
            Lote = lote;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;

        }
        // Empty constructor for EF
        protected Produto(){}
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public string Lote { get;private set; }
        public DateTime DataFabricacao { get; private set; }
        public DateTime DataValidade { get; private set; }
    }
   
}
