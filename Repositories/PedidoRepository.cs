using System;
using System.Collections;
using System.Collections.Generic;
using SistemaDeCompras.Models;
using SistemaDeCompras.Data;
using SistemaDeCompras.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace SistemaDeCompras.Repositories
{
    public class PedidoRepository:IPedidoRepository
    {       
        private readonly Context _context;
        //private readonly CarrinhoCompra _carrinhoCompra;
        
        public PedidoRepository(Context context){
           _context=context;
          // _carrinhoCompra=carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido){
            pedido.PedidoEnviado=DateTime.Now;
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

          //  var CarrinhoCompraItens=_carrinhoCompra.CarrinhoCompraItens;

            //foreach (var carrinhoitem in CarrinhoCompraItens)
           // {
             //   var pedidoDetail=new PedidoDetalhe(){
                //    Quantidade=carrinhoitem.Quantidade,
                //    ProdutoId=carrinhoitem.Produto.ProdutoId,
                //    PedidoId=pedido.PedidoId,
                   // Preco=carrinhoitem.Produto.Preco
               // };

               // _context.PedidoDetalhes.Add(pedidoDetail);
           // }

             _context.SaveChanges();
        }

        
    }
}