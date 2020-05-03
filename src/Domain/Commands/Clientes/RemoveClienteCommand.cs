using Domain.Validations.Clientes;
using System;

namespace Domain.Commands.Clientes
{
    public class RemoveClienteCommand : ClienteCommand
    {
        public RemoveClienteCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}