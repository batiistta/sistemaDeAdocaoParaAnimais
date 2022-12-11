using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using sistemaDeAdocaoParaAnimais.Helper;

namespace sistemaDeAdocaoParaAnimais.Models
{
    [MetadataType(typeof(Usuarios))]
    public class Usuarios
    {
        [Key]
        [Required]
        public int UsuarioId { get; set; }

        public virtual ICollection<Animal>? Animals { get; set; }

        public string? Avatar { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Display(Name = "Nome Social")]
        public string? NomeSocial { get; set; }

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
        [Display(Name = "Qual o nivel de adestramento do pet que você quer?")]
        [Range(1, 5)]
        public int Adestramento { get; set; }

        [Required]
        [Display(Name = "Termos & Condições")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Aceite os termos e condições.")]
        public bool TermosCondições { get; set; }

        public int fkCaracteristica {get; set;}

        public uint FkCluster {get; set;}

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
            ConfirmeSenha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}