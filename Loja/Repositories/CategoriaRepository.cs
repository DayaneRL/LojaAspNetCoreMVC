using Loja.Context;
using Loja.Models;
using Loja.Repositories.Interfaces;

namespace Loja.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
