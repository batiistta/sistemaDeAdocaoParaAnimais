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

        [ForeignKey("Caracteristica")]
        private int FkCaracteristica { get; set; }
        private virtual Caracteristica? Caracteristicas { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Nome")]
        private string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Raça")]
        private string Raca { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Cor")]
        private string Cor { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Descrição")]
        private string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Porte")]
        private int Porte { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Filhote")]
        private bool Filhote { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Adulto")]
        private bool Adulto { get; set; }
 
    }
}