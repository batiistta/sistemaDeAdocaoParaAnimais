using Microsoft.AspNetCore.Mvc;
using sistemaDeAdocaoParaAnimais.Helper;
using sistemaDeAdocaoParaAnimais.Models;
using sistemaDeAdocaoParaAnimais.Services;

namespace sistemaDeAdocaoParaAnimais.Controllers
{
    public class AlterarSenhaController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenha alterarSenha)
        {
            try
            {
                Usuarios usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                alterarSenha.Id = usuarioLogado.UsuarioId;
                
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.AlterarSenha(alterarSenha);
                    TempData["MensagemSucesso"] = $"Senha alterada com sucesso";
                }
                return View("Index", alterarSenha);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar sua senha, tente novamente.";
                return View("Index", alterarSenha);
            }
        }
    }
}