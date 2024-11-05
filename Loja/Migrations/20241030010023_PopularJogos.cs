using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loja.Migrations
{
    public partial class PopularJogos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("" +
                "INSERT INTO Jogos(CategoriaId, Descricao, DescricaoDetalhada, EmEstoque, ThumbnailUrl, ImagemUrl, JogoPreferido, Nome, Preco) " +
                "VALUES(1,'Puzzle de blocos','Tetris começa com uma tela vazia e exige que o jogador encaixe os blocos que caem como um quebra-cabeça', 1, " +
                "'https://upload.wikimedia.org/wikipedia/en/4/4a/Tetris_Boxshot.jpg','https://media.gamestop.com/i/gamestop/10152452/Tetris?$pdp$', 0, 'Tetris', 82.00)");

            migrationBuilder.Sql("INSERT INTO Jogos(CategoriaId, Descricao, DescricaoDetalhada, EmEstoque, ThumbnailUrl, ImagemUrl, JogoPreferido, Nome, Preco) " +
            "VALUES(1,'Super Mario Bros','Mario e Luigi tentam resgatar a princesa no reino dos cogumelos', 1, " +
            "'https://upload.wikimedia.org/wikipedia/en/2/22/Super-mario-land-gameboy-boxart.png','https://http2.mlstatic.com/D_NQ_NP_946799-MLA74246733633_012024-O.webp', 0, 'Super  Mario Bros', 80.91)");

            migrationBuilder.Sql("INSERT INTO Jogos(CategoriaId, Descricao, DescricaoDetalhada, EmEstoque, ThumbnailUrl, ImagemUrl, JogoPreferido, Nome, Preco) " +
            "VALUES(2,'Donkey Kong','O gorila Donkey Kong e seu sobrinho Diddy Kong partem em uma aventura para recuperar o tesouro e derrotar os Kremlings', 1, " +
            "'https://upload.wikimedia.org/wikipedia/pt/8/83/Donkey_Kong_Country_capa.png','https://www.neoelectronics.com.br/image/cache/catalog/produtos/Donkey%20Kong%20Cinza-800x800.png', 0, 'Donkey Kong', 75.00)");

            migrationBuilder.Sql("INSERT INTO Jogos(CategoriaId, Descricao, DescricaoDetalhada, EmEstoque, ThumbnailUrl, ImagemUrl, JogoPreferido, Nome, Preco) " +
            "VALUES(2,'Mortal Kombat','Mortal Kombat é um jogo de luta com ataques sangrentos e movimentos de finalização fatais', 1, " +
            "'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTEHWmsQsgLh3vggwn1Tb53WCQi70x66yfYiA&s'," +
            "'https://images-americanas.b2w.io/produtos/7391715580/imagens/cartucho-fita-ultimate-mortal-kombat-3-super-nintendo-snes/7391715580_1_xlarge.jpg', 1, 'Mortal Kombat', 115.00)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Jogos");
        }
    }
}
