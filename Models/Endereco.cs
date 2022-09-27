using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set;}

        [ForeignKey("Usuario")]
        public int FkUsuario { get; set; }
        public virtual Usuario? Usuarios { get; set; }

        [Required]
        [Display(Name = "Cep")]
        public string Cep { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required]
        [Display(Name = "Nome da rua")]
        public string Rua { get; set;}

    }
}