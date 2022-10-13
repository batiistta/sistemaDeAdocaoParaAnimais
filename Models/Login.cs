using System.ComponentModel.DataAnnotations;

namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Informe o login")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Informe a senha")]
        public string Senha { get; set; }
    }
};