namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Usuario
    {
        [key]
        [Required]
        private int Id { get; set;}

        [ForeignKey("Endereco")]
        private int FkEndereco { get; set; }
        private virtual Endereco? Enderecos { get; set; }   

        [Required]
        private virtual Icollection<Animal>? Animais { get; set; }

        [Required]
        [Display(Name = "Nome Completo")]
        [32,MinimumLength = 5, ErrorMessage ="Entre 5 e 32 caracteres."]
        private string Nome { get; set;}

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        private string Email { get; set;}

        [Required]
        [Compare("EmailAddress", ErrorMessage = "Os e-mails devem ser iguais.")]
        [Display(Name = "Confirme seu E-mail")]
        private string ConfirmeSenha { get; set;}

        [Required]
        [RegularExpression(^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$, 
        ErrorMessage = "Deve conter pelo menos 8 caracteres, pelo menos 1 número e letras minúsculas, maiúsculas e caracteres especiais(!@#$).")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        private string Senha { get; set;}

        [Required]
        [Compare("Password", ErrorMessage = "As senhas devem ser iguais.")]
        [Display(Name = "Confirme Senha")]
        private string ConfirmeSenha { get; set;}

        [Required]
        [Display (Name = "Idade")]
        [Range(18,60, ErrorMessage ="Idade válida entre 18 e 60 anos.")]
        private string Idade { get; set; }

        [Required(ErrorMessage ="Preenchimento obrigatório.")]
        [Display (Name = "Insira seu gênero.")]
        private string Genero { get; set; }

        [Required]
        [RegularExpression(^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$,
         ErrorMessage="Formato correto -> (xx) xxxxx-xxxx")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Celular")]
        private string Celular { get; set;}   

        [Required]
        [Display (Name = "Termos & Condições")]
        [Range(typeof(bool),"true", "true", ErrorMessage ="Aceite os termos e condições.")]
        private bool TermosCondições { get; set; }

    }
}