using Domain.Core.Commands;
using Domain.Core.Events;
using System.Threading.Tasks;

namespace Domain.Core.Bus
{
    /// <summary>
    /// Classe responsável por processar os Commands e os Events.
    /// </summary>
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
