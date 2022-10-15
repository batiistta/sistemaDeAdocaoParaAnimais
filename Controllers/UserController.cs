using Microsoft.AspNetCore.Mvc;

namespace sistemaDeAdocaoParaAnimais.Controllers
{
    public class UserController : Controller
    {
        
        public IActionResult Profile()
        {
            return View();
        }
    }
}