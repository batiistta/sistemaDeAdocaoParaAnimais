namespace sistemaDeAdocaoParaAnimais.Models.Animal
{
    public class Especie
    {
        [Key]
        [Required]
        private int Id { get; set; }
        
        [Required]
        [Display(Name = Tipo)]
        private string Tipo { get; set; }
        
        private virtual Icollection<Animal>? Animais { get; set; }
    }
    
}