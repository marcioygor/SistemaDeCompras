using Microsoft.EntityFrameworkCore;
using SistemaDeCompras.Models;

namespace SistemaDeCompras.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options):base(options){            
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }
       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("DataSource=app.db; Cache=Shared");
    }
}