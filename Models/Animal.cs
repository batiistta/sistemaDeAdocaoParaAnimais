namespace sistemaDeAdocaoParaAnimais.Models.Animal
{
    public class Animal
    {
        [Key]
        [Required]
        private int Id { get; set; }

        [ForeignKey("Usuario")]
        private int FkUsuario { get; set; }
        private virtual Usuario? Usuarios { get; set; }

        [ForeignKey("Especie")]
        private int FkEspecie { get; set; }
        private virtual Especie? Especies { get; set; }

        [Required]
        [Display(Name = "Nome")]
        private string Nome { get; set; }

        [Required]
        [Display(Name = "Raça")]
        private string Raca { get; set; }

        [Required]
        [Display(Name = "Cor")]
        private string Cor { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        private string Descricao { get; set; }

        [Required]
        [Display(Name = "Porte")]
        private int Porte { get; set; }

        [Required]
        [Display(Name = "Filhote")]
        private bool Filhote { get; set; }

        [Required]
        [Display(Name = "Adulto")]
        private bool Adulto { get; set; }

       
        
    
    }
}