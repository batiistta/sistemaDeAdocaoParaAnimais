namespace sistemaDeAdocaoParaAnimais.Models.Animal
{
    public abstract class Animal
    {
        public Animal()
        {

        }
        protected string Nome { get; set; }
        protected string Raca { get; set; }
        protected string Cor { get; set; }
        protected string Descricao { get; set; }
        protected int Introvertido { get; set;}
        protected int Agitado { get; set;}
        protected int Brincalhao { get; set;}
        protected int Timido { get; set;}
        protected bool Vacinado { get; set; }
        protected bool Castrado { get; set; }
        protected bool Vermifugado { get; set; }

        
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