using Domain.Models;

namespace Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente GetByEmail(string email);
    }
}
