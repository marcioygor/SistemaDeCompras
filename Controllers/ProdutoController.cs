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

   public IActionResult List(string categoria) //List?categoria=
    {
            IEnumerable<Produto> produtos;
            string categoriaAtual = string.Empty;

            if(string.IsNullOrEmpty(categoria))
            {
                produtos = _produtoRepository.Produtos.OrderBy(l => l.ProdutoId);
                categoriaAtual = "Todos os produtos";
            }
            else
            {
                if(string.Equals("ELETRODOMÉSTICO", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    produtos = _produtoRepository.Produtos
                        .Where(l => l.Categoria.CategoriaNome.Equals("ELETRODOMÉSTICO"))
                        .OrderBy(l => l.Nome);
                }
                else
                {
                    produtos = _produtoRepository.Produtos
                       .Where(l => l.Categoria.CategoriaNome.Equals("CASA, MESA E BANHO"))
                       .OrderBy(l => l.Nome);
                }
                categoriaAtual = categoria;
            }

            var produtoListViewModel = new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            };

            return View(produtoListViewModel);
    }
}
