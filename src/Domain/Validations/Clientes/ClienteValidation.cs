using Domain.Commands.Clientes;
using FluentValidation;
using System;

namespace Domain.Validations.Clientes
{
    public abstract class ClienteValidation<T> : AbstractValidator<T> where T : ClienteCommand
    {
        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Verifique se você digitou o Nome.")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres.");
        }

        protected void ValidateDataNascimento()
        {
            RuleFor(c => c.DataNascimento)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("O cliente deve ter 18 anos ou mais");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected static bool HaveMinimumAge(DateTime dataNascimento)
        {
            return dataNascimento <= DateTime.Now.AddYears(-18);
        }
    }
}