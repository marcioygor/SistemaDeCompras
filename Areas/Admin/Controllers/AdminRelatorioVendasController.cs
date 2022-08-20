using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCompras.Models;
using SistemaDeCompras.Areas.Admin.Services;

namespace SistemaDeCompras.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminRelatorioVendasController : Controller
    {
        private readonly RelatorioVendasService _relatorioVendasService;
        
        public AdminRelatorioVendasController(RelatorioVendasService relatorioVendasService){
            _relatorioVendasService=relatorioVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RelatorioVendasSimples(DateTime? mindate, DateTime? maxdate){

            if(!mindate.HasValue){
                mindate=new DateTime(DateTime.Now.Year, 1,1);
            }

            if(!maxdate.HasValue){
                maxdate=DateTime.Now;
            }

            ViewData["mindate"]=mindate.Value.ToString("yyyy-MM-dd");
            ViewData["maxdate"]=maxdate.Value.ToString("yyyy-MM-dd");

            var result= await _relatorioVendasService.FindByDateAsync(mindate,maxdate);

            return View(result);
        }
    }
}
