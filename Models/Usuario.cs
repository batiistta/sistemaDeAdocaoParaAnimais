namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Usuario
    {
        private int Id { get; set;}
        private string Nome { get; set; }
        private string Email { get; set;}
        private string Senha { get; set;}
        private string Telefone { get; set; }
        private Endereco Endereco { get; set; }
        
    }
}