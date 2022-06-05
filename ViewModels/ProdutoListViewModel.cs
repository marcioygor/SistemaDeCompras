using System;
using SistemaDeCompras.Models;

namespace SistemaDeCompras.ViewModels;

public class ProdutoListViewModel
{
    public IEnumerable<Produto> Produtos {get;set;}
    public string CategoriaAtual{get;set;}
}