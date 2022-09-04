using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using SistemaDeCompras.Data;
using SistemaDeCompras.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeCompras.Areas.Admin.Services{

 public class GraficoVendasService
 {
    private readonly Context _context;

      public GraficoVendasService(Context context)
       {
            _context = context;
       }

     public List<ProdutoGrafico> GetVendasProdutos(int dias=360){
        var data=DateTime.Now.AddDays(-dias);
        
        var produtos=(from pd in _context.PedidoDetalhes join l in _context.Produtos 
           on pd.ProdutoId equals l.ProdutoId where pd.Pedido.PedidoEnviado>=data
           group pd by new{pd.ProdutoId, l.Nome, pd.Quantidade}

           into g

           select new{
              ProdutoNome=g.Key.Nome,
              ProdutosQuantidade=g.Sum(q=>q.Quantidade),
              ProdutosValorTotal=g.Sum(a=>a.Preco*a.Quantidade)
           });

           var lista=new List<ProdutoGrafico>();

           foreach (var item in produtos)
           {
            var produto=new ProdutoGrafico();

            produto.ProdutoNome=item.ProdutoNome;
            produto.ProdutosQuantidade=item.ProdutosQuantidade;
            produto.ProdutosValorTotal=item.ProdutosValorTotal;

            lista.Add(produto);
            
           }
                          
         return lista;

     }

       
 }

}