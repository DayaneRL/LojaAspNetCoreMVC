using Loja.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        { 

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }  
    }
}
