using System;

namespace Domain.Interfaces
{
    namespace DNA.Domain.Interfaces
    {
        public interface IUnitOfWork : IDisposable
        {
            bool Commit();
        }
    }
}
