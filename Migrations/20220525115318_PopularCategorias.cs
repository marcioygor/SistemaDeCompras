using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeCompras.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql("INSERT INTO CATEGORIAS(CATEGORIANOME, DESCRICAO) VALUES('ELETRODOMÉSTICO', 'ELETRODOMÉSTICO EM GERAL')");
           migrationBuilder.Sql("INSERT INTO CATEGORIAS(CATEGORIANOME, DESCRICAO) VALUES('CASA, MESA E BANHO', 'MOVEIS PARA CASA MESA E BANHO')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql("DELETE FROM CATEGORIAS");
        }
    }
}
