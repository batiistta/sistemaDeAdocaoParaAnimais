namespace sistemaDeAdocaoParaAnimais.Models.Animal
{
    public class Animal
    {
        private int IdAnimal { get; set; }
        private string Nome { get; set; }
        private string Especie { get; set; }
        private string Raca { get; set; }
        private string Cor { get; set; }
        private string Descricao { get; set; }
        private int Porte { get; set; }
        private bool Filhote { get; set; }
        private bool Adulto { get; set; }

        private Caracteristica caracteristica { get; set; }
        private int IdEndereco { get; set;}
        private virtual Endereco endereco { get; set;}
        
    
    }
}