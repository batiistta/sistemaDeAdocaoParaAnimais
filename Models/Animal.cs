using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Pets
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int FkUsuario { get; set; }
        public virtual Usuario? Usuarios { get; set; }

        [ForeignKey("Especie")]
        public int FkEspecie { get; set; }
        public virtual Especie? Especies { get; set; }

        [ForeignKey("Caracteristica")]
        public int FkCaracteristica { get; set; }
        public virtual Caracteristica? Caracteristicas { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Raça")]
        public string Raca { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Cor")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Porte")]
        public int Porte { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Filhote")]
        public bool Filhote { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Adulto")]
        public bool Adulto { get; set; }

    }
}