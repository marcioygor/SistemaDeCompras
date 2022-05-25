using System.Collections;
using System.Collections.Generic;
using SistemaDeCompras.Models;
using SistemaDeCompras.Data;
using SistemaDeCompras.Repositories.Interfaces;

namespace SistemaDeCompras.Repositories
{
    public class CategoriaRepository:ICategoriaRepository
    {
        private readonly Context _context;
        
        public CategoriaRepository(Context context){
           _context=context;
        }

        public IEnumerable<Categoria> Categorias=>_context.Categorias;

    }
}