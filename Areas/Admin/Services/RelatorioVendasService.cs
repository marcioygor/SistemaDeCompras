using System;
using System.Collections.Generic;
using SistemaDeCompras.Data;
using SistemaDeCompras.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeCompras.Areas.Admin.Services{

 public class RelatorioVendasService
 {
    private readonly Context _context;


      public RelatorioVendasService(Context context)
       {
            _context = context;
       }

       public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate){

          var resultado= from obj in _context.Pedidos select obj;

          if(minDate.HasValue){
             
             resultado=resultado.Where(x=>x.PedidoEnviado>=minDate.Value);
          }

           if(maxDate.HasValue){
             
             resultado=resultado.Where(x=>x.PedidoEnviado<=maxDate.Value);
          }

          return await resultado.Include(l=>l.PedidoItens)
                                .ThenInclude(l=>l.Pedido)
                                .OrderByDescending(x=>x.PedidoEnviado)
                                .ToListAsync();

       }
 }

}