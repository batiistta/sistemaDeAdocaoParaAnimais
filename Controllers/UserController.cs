using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }
    
    

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }   

    public IActionResult Profile()
    {
        return View();
    }
    
    public IActionResult Recovery()
    {
        return View();
    }
   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
