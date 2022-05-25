using System.Collections.Generic;
using SistemaDeCompras.Models;

namespace SistemaDeCompras.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> Produtos{get;}
        Produto GetProdutoById(int ProdutoId);
    }
}