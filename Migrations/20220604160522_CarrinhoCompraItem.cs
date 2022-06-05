using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeCompras.Migrations
{
    public partial class CarrinhoCompraItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarrinhoCompraItemId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarrinhoCompraItens",
                columns: table => new
                {
                    CarrinhoCompraItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    CarrinhoCompraId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoCompraItens", x => x.CarrinhoCompraItemId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CarrinhoCompraItemId",
                table: "Produtos",
                column: "CarrinhoCompraItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_CarrinhoCompraItens_CarrinhoCompraItemId",
                table: "Produtos",
                column: "CarrinhoCompraItemId",
                principalTable: "CarrinhoCompraItens",
                principalColumn: "CarrinhoCompraItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_CarrinhoCompraItens_CarrinhoCompraItemId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "CarrinhoCompraItens");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CarrinhoCompraItemId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CarrinhoCompraItemId",
                table: "Produtos");
        }
    }
}
