using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Helper
{
    public interface ISessao
    {
         void CriarSessaoDoUsuario(Usuarios usuarios);
         void RemoverSessaoUsuario();
         Usuarios BuscarSessaoDoUsuario();
    }
}