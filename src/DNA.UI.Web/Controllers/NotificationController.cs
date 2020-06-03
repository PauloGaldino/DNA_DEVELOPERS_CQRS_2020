using Microsoft.AspNetCore.Mvc;

namespace DNA.UI.Web.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
