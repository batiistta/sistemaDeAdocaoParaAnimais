namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Usuario
    {
        private int UsuarioId { get; set;}
        private string Nome { get; set;}
        private string Email { get; set;}
        private string Senha { get; set;}
        private string Telefone { get; set;}
        private int EnderecoId { get; set;}
        private virtual Endereco endereco { get; set;}
        
    }
}