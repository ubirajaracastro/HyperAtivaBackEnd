using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuRH.Data.Migrations
{
    public partial class Cria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblUsuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(maxLength: 100, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsuario", x => x.UsuarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblUsuario");
        }
    }
}
