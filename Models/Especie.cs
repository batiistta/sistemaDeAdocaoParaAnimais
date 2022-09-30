using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Especie
    {
        [Key]
        [Required]
        public int EspecieId { get; set; }
        
        [Required]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [Required]
        public virtual ICollection<Animal> Animals { get; set; }
    }
}