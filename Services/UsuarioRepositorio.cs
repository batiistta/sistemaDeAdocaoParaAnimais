using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Services
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly SistemaDeAdocaoParaAnimaisContext _context; 

        public UsuarioRepositorio (SistemaDeAdocaoParaAnimaisContext sistemaDeAdocaoParaAnimaisContext)
        {
            this._context = sistemaDeAdocaoParaAnimaisContext; 
        }
        public Usuarios BuscarPorLogin(string email)
        {
            return _context.usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper()); 
        }
    }
}