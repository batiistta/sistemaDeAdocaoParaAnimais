using Microsoft.AspNetCore.Mvc;

namespace sistemaDeAdocaoParaAnimais.Controllers
{
    public class UserController : Controller
    {
        
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult CardsPets()
        {
            return View();
        }

        public IActionResult Recovery()
        {
            return View();
        }
    }
}