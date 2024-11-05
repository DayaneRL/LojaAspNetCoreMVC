using Loja.Models;
using Loja.Repositories.Interfaces;
using Loja.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IJogoRepository jogoRepository, CarrinhoCompra carrinhoCompra)
        {
            _jogoRepository = jogoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int JogoId)
        {
            var jogoSelecionar = _jogoRepository.Jogos
                .FirstOrDefault(p => p.Id == JogoId);

            if( jogoSelecionar != null )
            {
                _carrinhoCompra.AdicionarAoCarrinho(jogoSelecionar);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoverItemDoCarrinho(int JogoId)
        {
            var jogoSelecionar = _jogoRepository.Jogos
                .FirstOrDefault(p => p.Id == JogoId);

            if (jogoSelecionar == null)
            {
                _carrinhoCompra.RemoverDoCarrinho(jogoSelecionar);
            }

            return RedirectToAction("Index");
        }
    }
}
