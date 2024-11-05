using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loja.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("" +
                "INSERT INTO Categorias(Nome, Descricao) " +
                "VALUES('Game Boy','O Console portátil da Nintendo de grande sucesso')");

            migrationBuilder.Sql("" +
                "INSERT INTO Categorias(Nome, Descricao) " +
                "VALUES('Super Nintendo','SNES (Super Nintendo Entertainment System) foi a quarta geração de console desenvolvido pela Nintendo')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
