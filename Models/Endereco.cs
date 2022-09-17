namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Endereco
    {
        private int IdEndereco { get; set;}
        private string Cep { get; set; }
        private string Estado { get; set; }
        private string Cidade { get; set; }
        private string Bairro { get; set; }
        private string Rua { get; set;}
        private int IdUsuario { get; set;}
        private virtual Usuario usuario { get; set;}

    }
}