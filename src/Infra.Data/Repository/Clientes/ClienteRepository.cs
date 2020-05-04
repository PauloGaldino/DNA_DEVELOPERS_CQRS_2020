using Domain.Interfaces;
using Domain.Models;
using Infra.Data.Datas.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Infra.Data.Repository.Clientes
{
    /// <summary>
    /// Classe repositório dos metodos para pesquisa do cliente
    /// </summary>
   
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DnaDbContext context) : base(context)
        {

        }
        public Cliente GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
