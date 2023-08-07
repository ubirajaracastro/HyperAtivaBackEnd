using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuRH.Data.Migrations
{
    public partial class TabelaProcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCartao",
                columns: table => new
                {
                    CartaoId = table.Column<int>(maxLength: 100, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    Lote = table.Column<string>(nullable: false),
                    QtdeRegistros = table.Column<int>(nullable: false),
                    Identificador = table.Column<string>(nullable: false),
                    NumeroLote = table.Column<string>(nullable: false),
                    NumeroCartao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCartao", x => x.CartaoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCartao");
        }
    }
}
