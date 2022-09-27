namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Caracteristica
    {
        [Key]
        [Required]
        private int Id { get; set;} 

        [Required]
        private virtual Icollection<Animal>? Animais { get; set; }

        [Required]
        [Display(Name = "Energia")]
        [Range(1,5)]
        private int Energia { get; set; }

        [Required]
        [Display(Name = "Humor")]
        [Range(1,5)]
        private int Humor { get; set; }

        [Required]
        [Display(Name = "Apego")]
        [Range(1,5)]
        private int Apego { get; set; }

        [Required]
        [Range(1,5)]
        [Display(Name = "Latido")]
        private int Latido { get; set; }

        [Required]
        [Display(Name = "Inteligência")]
        [Range(1,5)]
        private int Inteligencia { get; set; }

        [Required]
        [Display(Name = "Brincadeira")]
        [Range(1,5)]
        private int Brincadeira { get; set; }

        [Required]
        [Display(Name = "Adestramento")]
        [Range(1,5)]
        private int Adestramento { get; set; }

        [Required]
        [Display(Name = "Vacinado ?")]
        [Range(1,5)]
        private bool Vacinado { get; set; }

        [Required]
        [Display(Name = "Castrado ?")]
        [Range(1,5)]
        private bool Castrado { get; set; }

        [Required]
        [Display(Name = "Vermifugado ?")]
        [Range(1,5)]
        private bool Vermifugado { get; set; }

    }
}