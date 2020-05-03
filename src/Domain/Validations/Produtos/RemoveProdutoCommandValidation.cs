using Domain.Commands.Produtos;

namespace Domain.Validations.Produtos
{
    public class RemoveProdutoCommandValidation : ProdutoValidation<RemoveProdutoCommand>
    {
        public RemoveProdutoCommandValidation()
        {
            ValidateId();
        }
    }
}
