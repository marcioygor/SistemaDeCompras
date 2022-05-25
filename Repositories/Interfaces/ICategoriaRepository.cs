using System.Collections.Generic;
using SistemaDeCompras.Models;

namespace SistemaDeCompras.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias{get;}
    }
}