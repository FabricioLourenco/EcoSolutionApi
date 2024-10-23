using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoSolution.Infra.Data.Migrations
{
    public partial class AjustetabelaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estacao",
                table: "Usuario",
                newName: "EstacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstacaoId",
                table: "Usuario",
                newName: "Estacao");
        }
    }
}
