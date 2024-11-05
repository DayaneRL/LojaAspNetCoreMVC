using Loja.Context;
using Loja.Models;
using Loja.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Loja.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly AppDbContext _context;
        public JogoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Jogo> Jogos => _context.Jogos.Include(c => c.Categoria);

        public IEnumerable<Jogo> JogosPreferidos => _context.Jogos
            .Where(j => j.JogoPreferido)
            .Include(c => c.Categoria);

        public Jogo GetJogoById(int jogoId)
        {
            return _context.Jogos.FirstOrDefault(j => j.Id == jogoId);
        }
    }
}
