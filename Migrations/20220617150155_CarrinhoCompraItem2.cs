using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeCompras.Migrations
{
    public partial class CarrinhoCompraItem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_CarrinhoCompraItens_CarrinhoCompraItemId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CarrinhoCompraItemId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CarrinhoCompraItemId",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "CarrinhoCompraItens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompraItens_ProdutoId",
                table: "CarrinhoCompraItens",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompraItens_Produtos_ProdutoId",
                table: "CarrinhoCompraItens",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompraItens_Produtos_ProdutoId",
                table: "CarrinhoCompraItens");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhoCompraItens_ProdutoId",
                table: "CarrinhoCompraItens");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "CarrinhoCompraItens");

            migrationBuilder.AddColumn<int>(
                name: "CarrinhoCompraItemId",
                table: "Produtos",
                type: "int",
                nullable: true);

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
    }
}
