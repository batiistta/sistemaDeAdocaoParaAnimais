using System.ComponentModel.DataAnnotations;
using Microsoft.ML.Data;

namespace sistemaDeAdocaoParaAnimais.Models
{
    public class CaracteristicaAnimal
    {
        [Key]
        [LoadColumn(0)]
        public int Id { get; set; }

        [Required]
        [LoadColumn(1)]
        public float Energia { get; set; }

        [Required]
        [LoadColumn(2)]
        public float Humor { get; set; }

        [Required]

        [LoadColumn(3)]
        public float Apego { get; set; }

        [Required]

        [LoadColumn(4)]
        public float Brincalhao { get; set; }

        [Required]
        [LoadColumn(5)]
        public float Adestramento { get; set; }
    }
}