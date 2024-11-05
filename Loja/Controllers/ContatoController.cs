using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
