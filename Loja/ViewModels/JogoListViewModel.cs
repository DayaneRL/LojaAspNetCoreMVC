using Loja.Models;

namespace Loja.ViewModels
{
    public class JogoListViewModel
    {
        public IEnumerable<Jogo> Jogos { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
