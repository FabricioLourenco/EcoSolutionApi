using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoSolution.Infra.Data.Migrations
{
    public partial class AjusteemUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuario",
                newName: "ChaveSecreta");

            migrationBuilder.AddColumn<long>(
                name: "Estacao",
                table: "Usuario",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estacao",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "ChaveSecreta",
                table: "Usuario",
                newName: "Senha");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Usuario",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
