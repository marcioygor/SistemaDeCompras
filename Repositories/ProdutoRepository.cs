using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using SistemaDeCompras.Models;
using SistemaDeCompras.Data;
using SistemaDeCompras.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeCompras.Repositories
{
    public class ProdutoRepository:IProdutoRepository
    {
        private readonly Context _context;
        
        public ProdutoRepository(Context context){
           _context=context;
        }

        public IEnumerable<Produto> Produtos=>_context.Produtos.Include(c=>c.Categoria);

        public Produto GetProdutoById(int ProdutoId){
          return _context.Produtos.FirstOrDefault(x=> x.ProdutoId==ProdutoId);
        }

    }
}