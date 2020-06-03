using Microsoft.AspNetCore.Mvc;

namespace DNA.UI.Web.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        [Route("welcome")]
        [Route("")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("sobre")]
        public IActionResult Sobre()
        {
            return View();
        }

        [Route("produto")]
        public IActionResult Produto()
        {
            return View();
        }

        [Route("portfólio")]
        public IActionResult Portfolio()
        {
            return View();
        }

        [Route("contato")]
        public IActionResult Contato()
        {
            return View();
        }

        [Route("error")]
        public IActionResult Error()
        {
            return View();
        }

        [Route("access-denied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
