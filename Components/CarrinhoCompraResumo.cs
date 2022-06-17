using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCompras.Models;
using SistemaDeCompras.ViewModels;

namespace SistemaDeCompras.Components;

public class CarrinhoCompraResumo:ViewComponent
{
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra ){
           _carrinhoCompra=carrinhoCompra;
    }

    public IViewComponentResult Invoke(){

        var itens=_carrinhoCompra.GetCarrinhoCompraItens();

          _carrinhoCompra.CarrinhoCompraItens=itens;

          var CarrinhoCompraVM=new CarrinhoCompraViewModel{
              CarrinhoCompra=_carrinhoCompra,
              CarrinhoCompraTotal=_carrinhoCompra.GetCarrinhoCompraTotal()
          };
                        
          return View(CarrinhoCompraVM);
    }
}