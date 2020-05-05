using Application.EventSourcedNomalizer.Cliente;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{

    public interface IClienteAppService : IDisposable
    {
        void Register(ClienteViewModel clienteViewModel);
        IEnumerable<ClienteViewModel> GetAll();
        ClienteViewModel GetById(Guid id);
        void Update(ClienteViewModel clienteViewModel);
        void Remove(Guid id);
        IList<ClienteHistoryData> GetAllHistory(Guid id);
    }
}
