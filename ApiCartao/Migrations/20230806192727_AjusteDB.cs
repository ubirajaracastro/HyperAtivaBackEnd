using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuRH.Data.Migrations
{
    public partial class AjusteDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identificador",
                table: "tblCartao");

            migrationBuilder.DropColumn(
                name: "NumeroCartao",
                table: "tblCartao");

            migrationBuilder.DropColumn(
                name: "NumeroLote",
                table: "tblCartao");

            migrationBuilder.CreateTable(
                name: "tblCartaoDetail",
                columns: table => new
                {
                    CartaoDetalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCartao = table.Column<string>(nullable: false),
                    Identificador = table.Column<string>(nullable: false),
                    NumeroLote = table.Column<string>(nullable: false),
                    NumeroCartaoCompleto = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCartaoDetail", x => x.CartaoDetalId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCartaoDetail");

            migrationBuilder.AddColumn<string>(
                name: "Identificador",
                table: "tblCartao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroCartao",
                table: "tblCartao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroLote",
                table: "tblCartao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
