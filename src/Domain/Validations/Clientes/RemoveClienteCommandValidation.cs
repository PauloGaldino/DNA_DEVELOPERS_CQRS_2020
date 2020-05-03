using Domain.Commands.Clientes;

namespace Domain.Validations.Clientes
{
    public class RemoveClienteCommandValidation : ClienteValidation<RemoveClienteCommand>
    {
        public RemoveClienteCommandValidation()
        {
            ValidateId();
        }
    }
}