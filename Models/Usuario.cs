namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Usuario
    {
        private int IdUsuario { get; set;}
        private string Nome { get; set;}
        private string Email { get; set;}
        private string Senha { get; set;}
        private string Telefone { get; set;}
        private int IdEndereco { get; set;}
        private virtual Endereco endereco { get; set;}
        
    }
}