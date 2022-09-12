namespace sistemaDeAdocaoParaAnimais.Models
{
    public class Usuario
    {
        public Usuario()
        {
            
        }
        public Usuario(string nome, string senha, string email, string telefone, Endereco endereco) 
        {
            this.Nome = nome;
            this.Senha = senha;
            this.Email = email;
            this.Telefone = telefone;
            this.endereco = endereco;
   
        }
        private string Nome { get; set; }
        private string Email { get; set;}
        private string Senha { get; set;}
        private string Telefone { get; set; }
        Endereco endereco = new Endereco();
     
        public Endereco getEndereco()
        {
            return this.endereco;
        }
        public void setEndereco(Endereco endereco){
            this.endereco = endereco;
        }
        
    }
}