namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        private int Id { get; set;}

        [Required]
        [Display(Name = "Cep")]
        private string Cep { get; set; }

        [Required]
        [Display(Name = "Estado")]
        private string Estado { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        private string Cidade { get; set; }

        [Required]
        [Display(Name = "Bairro")]
        private string Bairro { get; set; }

        [Required]
        [Display(Name = "Nome da rua")]
        private string Rua { get; set;}


    }
}