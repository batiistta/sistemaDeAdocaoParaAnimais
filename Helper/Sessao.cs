using Newtonsoft.Json;
using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext; 
        }
        public Usuarios BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuariologado");
            if(string.IsNullOrEmpty(sessaoUsuario)) return null; 
            return JsonConvert.DeserializeObject<Usuarios>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(Usuarios usuarios)
        {
            string valor = JsonConvert.SerializeObject(usuarios); 
            _httpContext.HttpContext.Session.SetString("sessaoUsuariologado", valor);
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}