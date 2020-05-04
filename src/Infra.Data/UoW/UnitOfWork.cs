using Domain.Interfaces.DNA.Domain.Interfaces;
using Infra.Data.Datas.Context;

namespace Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DnaDbContext _context;

        public UnitOfWork(DnaDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

