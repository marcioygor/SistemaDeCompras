using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCompras.Models;
using SistemaDeCompras.Repositories.Interfaces;
using SistemaDeCompras.Repositories;

namespace SistemaDeCompras.Controllers;

public class ProdutoController : Controller
{
    private readonly IProdutoRepository _produtoRepository;

      public ProdutoController(IProdutoRepository produtoRepository){
           _produtoRepository=produtoRepository;
        }

   public IActionResult List()
    {
        var produtos= _produtoRepository.Produtos.ToList();
        return View(produtos);
    }
}
