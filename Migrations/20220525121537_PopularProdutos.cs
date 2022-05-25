using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeCompras.Migrations
{
    public partial class PopularProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO PRODUTOS(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) VALUES(1,'TV SONY 45 POLEGADAS','SMART TV 4K',1, 'https://www.pioneerinter.com/img/1000x1000/products/532739/smart-tv-sony-bravia-xbr-49x835c-uhd-led-4k-49-cover-c.jpg','https://www.pioneerinter.com/img/1000x1000/products/532739/smart-tv-sony-bravia-xbr-49x835c-uhd-led-4k-49-cover-c.jpg', 0 ,'TV SONY 4K', 2850.99)");
            migrationBuilder.Sql("INSERT INTO PRODUTOS(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) VALUES(2,'SOFÁ RETRÁTIL E RECLINÁVEL','CAMA INBOX DIAMOND 2,25M TECIDO SUEDE VELUSOFT CINZA',1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRqRw7UMcL2mJh0Kp0lpdcCa_3pbla8Zvb8pg&usqp=CAU','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRqRw7UMcL2mJh0Kp0lpdcCa_3pbla8Zvb8pg&usqp=CAU', 0 ,'SOFÁ VELUSOFT', 3150.99)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql("DELETE FROM PRODUTOS");
        }
    }
}
