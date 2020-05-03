using Domain.Commands.Produtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validations.Produtos
{
    public abstract class ProdutoValidation<T> : AbstractValidator<T> where T : ProdutoCommand
    {
        protected void ValidateDescricao()
        {
            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("Verifique se você digitou o Nome.")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres.");
        }
        protected void ValidatePreco()
        {
            RuleFor(p => p.Preco)
                .NotEmpty().WithMessage("Verifique se você esqueceu de insrir o preço dp produto");
        }

        protected void ValidateFabricação()
        {
            RuleFor(p => p.DataFabricacao)
                .NotEmpty().WithMessage("Você deve inserir da data de fabricação");
        }
        protected void ValidateId()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty);
        }
        private bool HaveMinimumAge(DateTime arg)
        {
            throw new NotImplementedException();
        }
    }
}
