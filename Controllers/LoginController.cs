using Microsoft.AspNetCore.Mvc;
using sistemaDeAdocaoParaAnimais.Helper;
using sistemaDeAdocaoParaAnimais.Models;
using sistemaDeAdocaoParaAnimais.Services;

namespace sistemaDeAdocaoParaAnimais.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio; 
        private readonly ISessao _sessao; 
        public LoginController (IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio; 
            _sessao = sessao; 
        }
      
        public IActionResult Login()
        {
            //Se o usuario estiver logado redirecionar para home
            if(_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Login", "Login");
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
                            _sessao.CriarSessaoDoUsuario(usuarios);
                            return RedirectToAction("Profile", "User");
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