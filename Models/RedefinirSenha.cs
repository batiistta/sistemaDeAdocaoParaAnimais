using System.ComponentModel.DataAnnotations;

namespace sistemaDeAdocaoParaAnimais.Models
{
    public class RedefinirSenha
    {
        [Required(ErrorMessage ="Digite seu email")]
        public string Email { get; set; }
    }
}