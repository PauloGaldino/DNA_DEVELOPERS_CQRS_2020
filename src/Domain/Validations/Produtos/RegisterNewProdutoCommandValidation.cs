using Domain.Commands.Produtos;

namespace Domain.Validations.Produtos
{
    public class RegisterNewProdutoCommandValidation : ProdutoValidation<RegisterNewProdutoCommand>
    {
        public RegisterNewProdutoCommandValidation()
        {
            ValidateDescricao();
            ValidatePreco();
            ValidateFabricação();
        }
    }
}
