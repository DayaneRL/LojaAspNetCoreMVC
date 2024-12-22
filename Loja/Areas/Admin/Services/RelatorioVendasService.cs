using Loja.Context;
using Loja.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja.Areas.Admin.Services
{
    public class RelatorioVendasService
    {
        private readonly AppDbContext _context;

        public RelatorioVendasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.Pedidos select obj;

            if(minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }
            if(maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }

            return await resultado
                        .Include(j => j.PedidoItens)
                        .ThenInclude(j => j.Jogo)
                        .OrderByDescending(x => x.PedidoEnviado)
                        .ToListAsync();
        }
    }
}
