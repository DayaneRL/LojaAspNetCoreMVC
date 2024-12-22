using Loja.Models;
using Loja.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            int totalItens = 0;
            decimal precoTotal = 0.0m;

            //obter itens do carrinho de compra do cliente
            List<CarrinhoCompraItem> itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            //verifica se existem itens no pedido
            if(_carrinhoCompra.CarrinhoCompraItems.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho esta vazio, que tal incluir um produto...");
            }

            //calcular o total de itens e total do pedido
            foreach (var item in itens)
            {
                totalItens += item.Quantidade;
                precoTotal += (item.Jogo.Preco * item.Quantidade);
            }

            //atribui os valores obtidos ao pedido
            pedido.TotalItensPedido = totalItens;
            pedido.PedidoTotal = precoTotal;

            //valida os dados do pedido
            if (ModelState.IsValid)
            {
                //criar pedido e detalhes
                _pedidoRepository.CriarPedido(pedido);

                //define mensagens ao cliente
                ViewBag.CheckoutCompletoMsg = "Obrigado(a) pelo seu pedido :)";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

                //limpar carrinho
                _carrinhoCompra.LimparCarrinho();

                //exibir a view com dados do cliente e pedido
                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }


            return View(pedido);
        }
    }
}
