using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCompras.Models;
using SistemaDeCompras.Repositories.Interfaces;
using SistemaDeCompras.Repositories;
using SistemaDeCompras.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace SistemaDeCompras.Controllers;

public class CarrinhoCompraController : Controller
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

      public CarrinhoCompraController(IProdutoRepository produtoRepository, CarrinhoCompra carrinhoCompra ){
           _produtoRepository=produtoRepository;
           _carrinhoCompra=carrinhoCompra;
        }

       public IActionResult Index(){
          var itens=_carrinhoCompra.GetCarrinhoCompraItens();
          _carrinhoCompra.CarrinhoCompraItens=itens;

          var CarrinhoCompraVM=new CarrinhoCompraViewModel{
              CarrinhoCompra=_carrinhoCompra,
              CarrinhoCompraTotal=_carrinhoCompra.GetCarrinhoCompraTotal()
          };
                        
          return View(CarrinhoCompraVM);
    }


       [Authorize]
       public ActionResult AdicionarItemNoCarrinhoCompra(int ProdutoId){
           var produtoSelecionado=_produtoRepository.Produtos.FirstOrDefault(x=>x.ProdutoId==ProdutoId);

           if(produtoSelecionado!=null)
             _carrinhoCompra.AdicionarAoCarrinho(produtoSelecionado);

            return RedirectToAction("Index");

       }

        [Authorize]
        public ActionResult RemoverItemNoCarrinhoCompra(int ProdutoId){
           var produtoSelecionado=_produtoRepository.Produtos.FirstOrDefault(x=>x.ProdutoId==ProdutoId);

           if(produtoSelecionado!=null)
             _carrinhoCompra.AdicionarAoCarrinho(produtoSelecionado);

            return RedirectToAction("Index");

       }


}