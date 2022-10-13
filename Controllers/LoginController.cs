using Microsoft.AspNetCore.Mvc;
using sistemaDeAdocaoParaAnimais.Models;
using sistemaDeAdocaoParaAnimais.Services;

namespace sistemaDeAdocaoParaAnimais.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio; 

        public LoginController (IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio; 
        }
      
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(Login login)
        {
            try
            {
                if(ModelState.IsValid)
                {
                   Usuarios usuarios = _usuarioRepositorio.BuscarPorLogin(login.Email);
                    
                    if(usuarios != null)
                    {
                        if(usuarios.SenhaValida(login.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha do usuário é inválida, tente novamente.";
                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";    
                }

                return View("Login");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos achar seu cadastro.";
                return RedirectToAction("Login");
            }
        }
    }
}