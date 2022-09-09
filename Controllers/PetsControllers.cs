using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Controllers;

public class PetsController : Controller
{
    private readonly ILogger<PetsController> _logger;

    public PetsController(ILogger<PetsController> logger)
    {
        _logger = logger;
    }

    public IActionResult CardsPets()
    {
        return View();
    }


     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
