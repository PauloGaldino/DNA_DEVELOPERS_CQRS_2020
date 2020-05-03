using Domain.Validations.Produtos;
using System;

namespace Domain.Commands.Produtos
{
    public class RegisterNewProdutoCommand : ProdutoCommand
    {
        public RegisterNewProdutoCommand(string descricao, decimal preco, DateTime dataFabricacao, DateTime dataValidade)
        {
            Descricao = descricao;
            Preco = preco;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProdutoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
