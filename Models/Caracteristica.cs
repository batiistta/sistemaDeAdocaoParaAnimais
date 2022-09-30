using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Caracteristica
    {
        [Key]
        [Required]
        public int Id { get; set;} 

        [Required]
        public virtual ICollection<Animal>? Animals { get; set; }

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

    }
}