using Domain.Commands.Produtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validations.Produtos
{
    public class UpdateProdutoCommandValidatiom : ProdutoValidation<UpdateProdutoCommand>
    {
        public UpdateProdutoCommandValidatiom()
        {
            ValidateId();
            ValidateDescricao();
            ValidatePreco();
            ValidateFabricação();
        }
    }
}
