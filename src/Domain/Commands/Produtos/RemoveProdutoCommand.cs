using Domain.Validations.Produtos;
using System;

namespace Domain.Commands.Produtos
{
    public class RemoveProdutoCommand : ProdutoCommand
    {
        public RemoveProdutoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveProdutoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
