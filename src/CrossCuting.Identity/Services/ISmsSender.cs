using System.Threading.Tasks;

namespace CrossCuting.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
