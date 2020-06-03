using Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DNA.UI.Web.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly DomainNotificationHandler _notifications;

        public SummaryViewComponent(DomainNotificationHandler notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult((_notifications.GetNotifications()));
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));

            return View();
        }
    }
}
