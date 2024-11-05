using Loja.Models;

namespace Loja.Repositories.Interfaces
{
    public interface IJogoRepository
    {
        IEnumerable<Jogo> Jogos { get; }

        IEnumerable<Jogo> JogosPreferidos { get; }

        Jogo GetJogoById(int  jogoId);
    }
}
