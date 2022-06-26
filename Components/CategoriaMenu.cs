using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCompras.Models;
using SistemaDeCompras.ViewModels;
using SistemaDeCompras.Repositories.Interfaces;

namespace SistemaDeCompras.Components
{
    public class CategoriaMenu:ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

         public CategoriaMenu(ICategoriaRepository categoriaRepository ){
           _categoriaRepository=categoriaRepository;
    }


       public IViewComponentResult Invoke(){

          var categorias=_categoriaRepository.Categorias.OrderBy(c=>c.CategoriaNome);                       
          return View(categorias);
    }



    }
}