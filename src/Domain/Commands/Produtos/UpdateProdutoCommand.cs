using Domain.Validations.Produtos;
using System;

namespace Domain.Commands.Produtos
{
    public class UpdateProdutoCommand : ProdutoCommand
    {
        public UpdateProdutoCommand(Guid id, string descricao, decimal preco, string lote, DateTime dataFabricacao, DateTime dataValidade)
        {
            Id = id;
            Descricao = descricao;
            Preco = preco;
            Lote = lote;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateProdutoCommandValidatiom().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
