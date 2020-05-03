using Domain.Commands.Clientes;

namespace Domain.Validations.Clientes
{
    public class RegisterNewClienteCommandValidation : ClienteValidation<RegisterNewClienteCommand>
    {
        public RegisterNewClienteCommandValidation()
        {
            ValidateNome();
            ValidateDataNascimento();
            ValidateEmail();
        }
    }
}