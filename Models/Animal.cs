namespace sistemaDeAdocaoParaAnimais.Models.Animal
{
    public class Animal
    {
        private string Nome { get; set; }
        private string Raca { get; set; }
        private string Cor { get; set; }
        private string Descricao { get; set; }
        private int Porte { get; set; }
        private int Agitado { get; set;}
        private int Brincalhao { get; set;}
        private int Timido { get; set;}
        private int Dorminhoco { get; set; }
        private int Obediente { get; set; }
        private bool Vacinado { get; set; }
        private bool Castrado { get; set; }
        private bool Vermifugado { get; set; }
        private Endereco Endereco { get; set; }
        
    
    }
}