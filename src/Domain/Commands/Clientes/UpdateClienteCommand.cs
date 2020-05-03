using Domain.Validations.Clientes;
using System;

namespace Domain.Commands.Clientes
{
    public class UpdateClienteCommand : ClienteCommand
    {
        public UpdateClienteCommand(Guid id, string nome, string email, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}