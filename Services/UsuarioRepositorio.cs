using sistemaDeAdocaoParaAnimais.Helper;
using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Services
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly SistemaDeAdocaoParaAnimaisContext _context;
        private readonly ISessao _sessao;

        public UsuarioRepositorio(SistemaDeAdocaoParaAnimaisContext sistemaDeAdocaoParaAnimaisContext, ISessao sessao)
        {
            this._context = sistemaDeAdocaoParaAnimaisContext;
            _sessao = sessao;
        }

        public Usuarios Atualizar(Usuarios usuarios)
        {
            Usuarios usuariosBD = ListarPorId(usuarios.UsuarioId);

            if (usuariosBD == null) throw new System.Exception("Houve um erro na atualização do usuario");

            usuariosBD.Senha = usuarios.Senha;
            usuariosBD.ConfirmeSenha = usuarios.ConfirmeSenha;

            _context.usuarios.Update(usuariosBD);
            _context.SaveChanges();

            return usuariosBD;
        }

        public Usuarios AlterarSenha(AlterarSenha alterarSenha)
        {
            Usuarios usuariosDB = ListarPorId(alterarSenha.Id);

            if (usuariosDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado");

            if (!usuariosDB.SenhaValida(alterarSenha.SenhaAtual)) throw new Exception("Senha atual não confere!");

            if (usuariosDB.SenhaValida(alterarSenha.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual");

            usuariosDB.SetNovaSenha(alterarSenha.NovaSenha);

            _context.usuarios.Update(usuariosDB);
            _context.SaveChanges();

            return usuariosDB;
        }

        public Usuarios BuscarPorEmail(string email)
        {
            return _context.usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());
        }

        public Usuarios BuscarPorLogin(string email)
        {
            return _context.usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());
        }

        public Usuarios ListarPorId(int id)
        {
            return _context.usuarios.FirstOrDefault(x => x.UsuarioId == id);
        }

        public Usuarios BuscarPorUsuario(string cpf)
        {
            return _context.usuarios.FirstOrDefault(x => x.CPF == cpf);
        }
    }
}