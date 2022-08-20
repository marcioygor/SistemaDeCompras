using System;
using SistemaDeCompras.Models;

namespace SistemaDeCompras.ViewModels;

public class PedidoProdutoViewModel
{ 
    public Pedido Pedido {get;set;}
    public IEnumerable<PedidoDetalhe> PedidoDetalhes {get;set;}
}