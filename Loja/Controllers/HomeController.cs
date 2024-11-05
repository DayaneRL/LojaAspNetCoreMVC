using Loja.Models;
using Loja.Repositories.Interfaces;
using Loja.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Loja.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJogoRepository _jogoRepository;

        public HomeController(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                JogosPreferidos = _jogoRepository.JogosPreferidos
            };

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
