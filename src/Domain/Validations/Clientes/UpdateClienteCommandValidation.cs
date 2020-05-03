using Domain.Commands.Clientes;

namespace Domain.Validations.Clientes
{
    public class UpdateClienteCommandValidation : ClienteValidation<UpdateClienteCommand>
    {
        public UpdateClienteCommandValidation()
        {
            ValidateId();
            ValidateNome();
            ValidateDataNascimento();
            ValidateEmail();
        }
    }
}