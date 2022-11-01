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

        [Required]
        [Display(Name = "Energia")]
        [Range(1,5)]
        public int Energia { get; set; }

        [Required]
        [Display(Name = "Humor")]
        [Range(1,5)]
        public int Humor { get; set; }

        [Required]
        [Display(Name = "Apego")]
        [Range(1,5)]
        public int Apego { get; set; }

        [Required]
        [Range(1,5)]
        [Display(Name = "Latido")]
        public int Latido { get; set; }

        [Required]
        [Display(Name = "Inteligência")]
        [Range(1,5)]
        public int Inteligencia { get; set; }

        [Required]
        [Display(Name = "Brincadeira")]
        [Range(1,5)]
        public int Brincadeira { get; set; }

        [Required]
        [Display(Name = "Adestramento")]
        [Range(1,5)]
        public int Adestramento { get; set; }

        [Required]
        [Display(Name = "Vacinado ?")]
        [Range(1,5)]
        public bool Vacinado { get; set; }

        [Required]
        [Display(Name = "Castrado ?")]
        [Range(1,5)]
        public bool Castrado { get; set; }

        [Required]
        [Display(Name = "Vermifugado ?")]
        [Range(1,5)]
        public bool Vermifugado { get; set; }

        [Required]
        [Display (Name = "Insira uma imagem")]
        public string ImagensPet { get; set; }

    }
}