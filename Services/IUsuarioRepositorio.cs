using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Services
{
    public interface IUsuarioRepositorio
    {
        Usuarios ListarPorId(int id);
        Usuarios BuscarPorLogin(string email);
        Usuarios BuscarPorEmail(string email);
        Usuarios Atualizar(Usuarios usuarios);
        Usuarios AlterarSenha(AlterarSenha alterarSenha);
        Usuarios BuscarPorUsuario(string cpf);
    }
}