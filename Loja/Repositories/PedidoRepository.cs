using Loja.Context;
using Loja.Models;
using Loja.Repositories.Interfaces;

namespace Loja.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);
            _appDbContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;
            
            foreach(var carrinhoItem in  carrinhoCompraItens)
            {
                var pedidoDetalhe = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    JogoId = carrinhoItem.Jogo.Id,
                    PedidoId = pedido.Id,
                    Preco = carrinhoItem.Jogo.Preco
                };

                _appDbContext.PedidoDetalhes.Add(pedidoDetalhe);
            }

            _appDbContext.SaveChanges();
        }
    }
}
