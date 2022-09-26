namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Caracteristica
    {
        [Key]
        [Required]
        private int Id { get; set;} 

        [Required]
        [Display(Name = "Energia")]
        private int Energia { get; set; }

        [Required]
        [Display(Name = "Humor")]
        private int Humor { get; set; }

        [Required]
        [Display(Name = "Apego")]
        private int Apego { get; set; }

        [Required]
        [Display(Name = "Latido")]
        private int Latido { get; set; }

        [Required]
        [Display(Name = "Inteligência")]
        private int Inteligencia { get; set; }

        [Required]
        [Display(Name = "Brincadeira")]
        private int Brincadeira { get; set; }

        [Required]
        [Display(Name = "Adestramento")]
        private int Adestramento { get; set; }

        [Required]
        [Display(Name = "Vacinado ?")]
        private bool Vacinado { get; set; }

        [Required]
        [Display(Name = "Castrado ?")]
        private bool Castrado { get; set; }

        [Required]
        [Display(Name = "Vermifugado ?")]
        private bool Vermifugado { get; set; }

    }
}