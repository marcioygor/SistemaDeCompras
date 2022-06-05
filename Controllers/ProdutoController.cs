using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCompras.Models;
using SistemaDeCompras.Repositories.Interfaces;
using SistemaDeCompras.Repositories;
using SistemaDeCompras.ViewModels;

namespace SistemaDeCompras.Controllers;

public class ProdutoController : Controller
{
    private readonly IProdutoRepository _produtoRepository;

      public ProdutoController(IProdutoRepository produtoRepository){
           _produtoRepository=produtoRepository;
        }

   public IActionResult List()
    {
        ViewData["Titulo"]="Categoria Atual";
        ViewData["Data"]= DateTime.Now;

        //var produtos= _produtoRepository.Produtos.ToList();
        var produtoListViewModel=new ProdutoListViewModel();
        produtoListViewModel.Produtos=_produtoRepository.Produtos.ToList();
        produtoListViewModel.CategoriaAtual="Categoria Atual";

        var TotalProdutos=produtoListViewModel.Produtos.Count();

        ViewBag.Total="Todos os produtos";
        ViewBag.TotalProdutos=TotalProdutos;

        return View(produtoListViewModel);
    }
}
