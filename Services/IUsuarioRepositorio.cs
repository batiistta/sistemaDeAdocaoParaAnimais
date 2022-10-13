using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Services
{
    public interface IUsuarioRepositorio
    {
         Usuarios BuscarPorLogin(string email);
    }
}