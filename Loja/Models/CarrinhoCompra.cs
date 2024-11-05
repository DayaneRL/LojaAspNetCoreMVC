
using Loja.Context;
using Microsoft.EntityFrameworkCore;

namespace Loja.Models
{
    public class CarrinhoCompra
    {

        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }
        
        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            
            //obtem um servico do tipo do contexto
            var context = services.GetService<AppDbContext>();

            //obtem ou gera Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId")?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na sessao
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e o id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Jogo jogo)
        {
            var CarrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                s => s.Jogo.Id == jogo.Id &&
                     s.CarrinhoCompraId == CarrinhoCompraId
            );

            if(CarrinhoCompraItem == null )
            {
                CarrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Jogo = jogo,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add( CarrinhoCompraItem );
            }
            else
            {
                CarrinhoCompraItem.Quantidade++;
            }

            _context.SaveChanges();
        }

        public int RemoverDoCarrinho(Jogo jogo)
        {
            var CarrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
               s => s.Jogo.Id == jogo.Id &&
                    s.CarrinhoCompraId == CarrinhoCompraId
            );

            var quantTotal = 0;

            if (CarrinhoCompraItem != null)
            {
                if (CarrinhoCompraItem.Quantidade > 1)
                {
                    CarrinhoCompraItem.Quantidade--;
                    quantTotal = CarrinhoCompraItem.Quantidade;
                }
                else
                {
                    _context.CarrinhoCompraItens.Remove(CarrinhoCompraItem);
                }
            }

            _context.SaveChanges();
            return quantTotal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItems ??
                (CarrinhoCompraItems =
                    _context.CarrinhoCompraItens
                    .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                    .Include(s=> s.Jogo)
                    .ToList()
                );
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId);

            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Select(c => c.Jogo.Preco * c.Quantidade).Sum();

            return total;
        }
    }
}
