using Application.EventSourcedNomalizer.Produtos;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        void Register(ProdutoViewModel produtoViewModel);
        IEnumerable<ProdutoViewModel> GetAll();
        ProdutoViewModel GetById(Guid id);
        void Update(ProdutoViewModel produtoViewModel);
        void Remove(Guid id);
        IList<ProdutoHistoryData> GetAllHistory(Guid id);
    }
}
