namespace sistemaDeAdocaoParaAnimais.Models.Animal
{
    public class Animal
    {
        private int IdAnimal { get; set; }
        private string Nome { get; set; }
        private string Raca { get; set; }
        private string Cor { get; set; }
        private string Descricao { get; set; }
        private int Porte { get; set; }
        private bool Filhote { get; set; }
        private bool Adulto { get; set; }
        private int Energia { get; set; }
        private int Humor { get; set; }
        private int Apego { get; set; }
        private int Latido { get; set; }
        private int Inteligencia { get; set; }
        private int Brincadeira { get; set; }
        private int Adestramento { get; set; }
        private bool Vacinado { get; set; }
        private bool Castrado { get; set; }
        private bool Vermifugado { get; set; }

        private int IdEndereco { get; set;}
        private virtual Endereco endereco { get; set;}
        
    
    }
}