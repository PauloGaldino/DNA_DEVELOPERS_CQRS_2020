using Domain.Interfaces;
using Domain.Models;
using Infra.Data.Datas.Context;

namespace Infra.Data.Repository.Produtos
{
    /// <summary>
    /// Classe repositório para produtos
    /// </summary>
     public class ProdutoReposiory : Repository<Produto>, IProdutoRepository
    {
        public ProdutoReposiory(DnaDbContext context):base(context)
        {
                
        }
    }
}
