using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Animal
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Usuarios")]
        [Required]
        public int FkUsuarios { get; set; }
        public virtual Usuarios? Usuarios { get; set; }

        [ForeignKey("Especie")]
        [Required]
        public int FkEspecie { get; set; }
        public virtual Especie? Especies { get; set; }

        [ForeignKey("Caracteristica")]
        [Required]
        public int FkCaracteristica { get; set; }
        public virtual Caracteristica? Caracteristicas { get; set; }

        [Required]
        [Display (Name = "Insira uma imagem")]
        public string ImagensPet { get; set; }

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