namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Usuario
    {
        [key]
        [Required]
        private int Id { get; set;}

        [Required]
        [Display(Name = "Nome Completo")]
        private string Nome { get; set;}

        [Required]
        [Display(Name = "E-mail")]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage = "Formato de e-mail inválido.")]
        [DataType(DataType.Email)]
        private string Email { get; set;}

        [Required]
        [Compare("Email", ErrorMessage = "Os e-mails devem ser iguais.")]
        [Display(Name = "Confirme seu E-mail")]
        private string ConfirmeSenha { get; set;}

        [Required]
        [RegularExpression(^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$, ErrorMessage = "Deve conter pelo menos 8 caracteres, pelo menos 1 número e letras minúsculas, maiúsculas e caracteres especiais.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        private string Senha { get; set;}

        [Required]
        [Compare("Password", ErrorMessage = "As senhas devem ser iguais.")]
        [Display(Name = "Confirme Senha")]
        private string ConfirmeSenha { get; set;}

        [Required]
        [RegularExpression(^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$,
         ErrorMessage="(xx) xxxxx-xxxx")]
        [Display(Name = "Celular")]
        private string Celular { get; set;}
        
        private virtual Icollection<Animal>? Animais { get; set; }
    
    }
}