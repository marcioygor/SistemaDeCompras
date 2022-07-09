using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeCompras.Models;

public class PedidoDetalhe
{
   public int PedidoDetalheId{get;set;}

   public int PedidoId {get;set;}

   public int ProdutoId {get;set;}

   public int Quantidade {get;set;}

   [Column(TypeName = "decimal(18,2)")]
   public decimal Preco;

   public Produto Produto;

   public Pedido Pedido;
}

