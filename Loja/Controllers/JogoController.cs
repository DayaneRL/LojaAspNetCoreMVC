using Loja.Models;
using Loja.Repositories.Interfaces;
using Loja.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{
    public class JogoController : Controller
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoController(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public IActionResult List(string categoria)
        {

            IEnumerable<Jogo> jogos;
            string categoriaAtual = string.Empty;

            if(string.IsNullOrEmpty(categoria))
            {
                jogos = _jogoRepository.Jogos.OrderBy(j=>j.Id);
                categoriaAtual = "Todos os Jogos";
            }
            else
            {
                jogos = _jogoRepository.Jogos
                    .Where(j => j.Categoria.Nome.Equals(categoria))
                    .OrderBy(j => j.Nome);

                categoriaAtual = categoria;
            }

            var jogosListViewModel = new JogoListViewModel
            {
                Jogos = jogos,
                CategoriaAtual = categoriaAtual,
            };

            return View(jogosListViewModel);
        }

        public IActionResult Details(int JogoId)
        {
            var jogo = _jogoRepository.Jogos
                .FirstOrDefault(j => j.Id == JogoId);
            return View(jogo);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Jogo> jogos;
            string categoriaAtual = string.Empty;

            if(string.IsNullOrEmpty(searchString))
            {
                jogos = _jogoRepository.Jogos.OrderBy(j => j.Id);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                jogos = _jogoRepository.Jogos
                    .Where(j => j.Nome.ToLower().Contains(searchString.ToLower()))
                    .OrderBy(j => j.Id);

                if (jogos.Any())
                {
                    categoriaAtual = "Jogos";
                }
                else
                {
                    categoriaAtual = "Nenhum jogo foi encontrado";
                }
            }

            return View("~/Views/Jogo/List.cshtml", new JogoListViewModel
            {
                Jogos = jogos,
                CategoriaAtual=categoriaAtual,
            });
        }
    }
}
