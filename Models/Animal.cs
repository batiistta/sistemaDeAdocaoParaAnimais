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
        [Display(Name = "Conte um pouco da sua historia com o pet")]
        [StringLength(623, ErrorMessage = "A historia do pet nao pode conter mais de 115 caracrteres. ")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Porte")]
        public string Porte { get; set; }

        [Required]
        [Display(Name = ("Espécie"))]
        public string Especie { get; set; }

        [Required]
        [Display(Name = ("Informe o sexo do pet"))]
        public string Sexo { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required]
        [Display(Name = "Vacinado ?")]
        public string Vacinado { get; set; }

        [Required]
        [Display(Name = "Castrado ?")]
        public string Castrado { get; set; }

        [Required]
        [Display(Name = "Vermifugado ?")]
        public string Vermifugado { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Status do Pet")]
        public string EstadoAdocaoPet { get; set; }

        [Required(ErrorMessage = "É obrigatório enviar uma foto do pet")]
        [Display(Name = "Insira uma foto do pet")]
        public string ImagensPet { get; set; }

        public int FkCaracteristicaAnimal {get; set;}
        
        public uint FkCluster {get; set;}

    }
}