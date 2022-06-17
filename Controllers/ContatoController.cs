using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCompras.Models;

namespace SistemaDeCompras.Controllers;

public class ContatoController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public IActionResult Index()
    {
        return View();
    }


}
