using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set;}

        [ForeignKey("Endereco")]
        public int FkEndereco { get; set; }
        public virtual Endereco? Enderecos { get; set; }   

        [Required]
        public virtual ICollection<Pets>? Pets { get; set; }

        [Required]
        [Display(Name = "Nome Completo")]
        [StringLength(32,MinimumLength=5, ErrorMessage = "O nome deve ter entre 5 e 32 caracteres")]
       public string Nome { get; set;}

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set;}

        [Required]
        [Compare("EmailAddress", ErrorMessage = "Os e-mails devem ser iguais.")]
        [Display(Name = "Confirme seu E-mail")]
        public string ConfirmeEmail{ get; set;}

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
        ErrorMessage = "Deve conter pelo menos 8 caracteres, pelo menos 1 número e letras minúsculas, maiúsculas e caracteres especiais(!@#$).")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set;}

        [Required]
        [Compare("Password", ErrorMessage = "As senhas devem ser iguais.")]
        [Display(Name = "Confirme Senha")]
        public string ConfirmeSenha { get; set;}

        [Required]
        [Display (Name = "Idade")]
        [Range(18,60, ErrorMessage ="Idade válida entre 18 e 60 anos.")]
        public string Idade { get; set; }

        [Required(ErrorMessage ="Preenchimento obrigatório.")]
        [Display (Name = "Insira seu gênero.")]
        public string Genero { get; set; }

        [Required]
        [RegularExpression("^([1-9]{2})(?:[2-8]|9[1-9])[0-9]{3}-[0-9]{4}$",
         ErrorMessage="Formato correto -> (xx) xxxxx-xxxx")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Celular")]
       public string Celular { get; set;}   

        [Required]
        [Display (Name = "Termos & Condições")]
        [Range(typeof(bool),"true", "true", ErrorMessage ="Aceite os termos e condições.")]
       public bool TermosCondições { get; set; }

    }
}