using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace sistemaDeAdocaoParaAnimais.Models
{
    [MetadataType(typeof(Usuarios))]
    public class Usuarios
    {
        [Key]
        [Required]
        public int UsuarioId { get; set; }

        public virtual ICollection<Animal>? Animals { get; set; }

        [Required]
        [Display(Name = "Nome Completo")]
        [StringLength(32, MinimumLength = 5, ErrorMessage = "O nome tem que ter entre 5 e 32 caracteres")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "CPF")]
        [RegularExpression("^[0-9]{3}.?[0-9]{3}.?[0-9]{3}-?[0-9]{2}", ErrorMessage = "Formato incorreto")]
        public string CPF { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Confirme seu E-mail")]
        [DataType(DataType.EmailAddress)]
        [Compare(nameof(Email), ErrorMessage = "Os e-mails devem ser iguais.")]
        public string ConfirmeEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
        ErrorMessage = "Deve conter pelo menos 8 caracteres, pelo menos 1 número e letras minúsculas, maiúsculas e caracteres especiais(!@#$).")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Senha), ErrorMessage = "As senhas devem ser iguais.")]
        [Display(Name = "Confirme Senha")]
        public string ConfirmeSenha { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public string DtNascimento { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório.")]
        [Display(Name = "Insira seu gênero.")]
        public string Genero { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("([1-9]{2})(?:[2-8]|9[1-9])[0-9]{3}[0-9]{4}$",
         ErrorMessage = "Formato correto -> (xx) xxxxx-xxxx")]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Required]
        [Display(Name = "Cep")]
        public string Cep { get; set; }

        [Required]
        [Display(Name = "Logradouro")]
        public string Rua { get; set; }

        [Required]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O número da casa precisa ser preenchido")]
        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        public string complemento { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required]
        [Display(Name = "Termos & Condições")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Aceite os termos e condições.")]
        public bool TermosCondições { get; set; }
    
        public bool SenhaValida(string senha)
        {
            return Senha == senha; 
        }
 
    }
}