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
        private readonly IEmail _email;

        private SistemaDeAdocaoParaAnimaisContext _sistemaDeAdocaoParaAnimaisContext;
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao, IEmail email, SistemaDeAdocaoParaAnimaisContext sistemaDeAdocaoParaAnimaisContext)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
            _sistemaDeAdocaoParaAnimaisContext = sistemaDeAdocaoParaAnimaisContext; 
        }

        public IActionResult Login()
        {
            //Se o usuario estiver logado redirecionar para home
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Entrar(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuarios usuarios = _usuarioRepositorio.BuscarPorLogin(login.Email);

                    if (usuarios != null)
                    {
                        if (usuarios.SenhaValida(login.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuarios);
                            return RedirectToAction("Buscar", "Animais");
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

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenha redefinirSenha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuarios usuarios = _usuarioRepositorio.BuscarPorEmail(redefinirSenha.Email);

                    if (usuarios != null)
                    {
                        string novaSenha = usuarios.GerarNovaSenha();

                        string mensagem = $"Sua nova senha é: {novaSenha}";

                        bool emailEnviado = _email.Enviar(usuarios.Email, "Animal Pets - Nova Senha", mensagem);
                        
                        if(emailEnviado)
                        {
                            _usuarioRepositorio.Atualizar(usuarios);
                        } else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar o e-mail. Por favor tente novamente.";
                        }
                        
                        TempData["MensagemErro"] = $"Enviamos para seu e-mail uma nova senha";
                        return RedirectToAction("Login", "Login");
                    }
                    TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha, verifique os dados informados.";
                    return RedirectToAction("RedefinirSenha", "Login");
                }

                return View("Login");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos redefinir sua senha";
                return RedirectToAction("Login");
            }
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }
    }
}