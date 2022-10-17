using System.ComponentModel.DataAnnotations;

namespace sistemaDeAdocaoParaAnimais.Models
{
    public class AlterarSenha
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite a senha atual do usuário")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Digite a nova senha do usuário")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme a nova senha do usuário")]
        [Compare("NovaSenha", ErrorMessage = "A senha não confere com a nova senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a nova Senha")]
        public string ConfirmarNovaSenha { get; set; }
    }
}