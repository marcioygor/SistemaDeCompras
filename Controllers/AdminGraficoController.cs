using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCompras.Models;
using SistemaDeCompras.Areas.Admin.Services;

namespace SistemaDeCompras.Controllers;

public class AdminGraficoController : Controller
{
    private readonly GraficoVendasService _graficoVendas;

       public AdminGraficoController(GraficoVendasService graficoVendas)
        {
            _graficoVendas = graficoVendas;
        }

      public JsonResult VendasProdutos(int dias)
        {
            var produtosVendasTotais = _graficoVendas.GetVendasProdutos(dias);
            return Json(produtosVendasTotais);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasMensal()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasSemanal()
        {
            return View();
        }


}
