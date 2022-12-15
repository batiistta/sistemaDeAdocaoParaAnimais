using System.ComponentModel.DataAnnotations;
using Microsoft.ML.Data;

namespace sistemaDeAdocaoParaAnimais.Models
{
    public static class CaracteristicaUsuarioTeste
    {
        internal static readonly CaracteristicaUsuario caracteristicaUsuario = new CaracteristicaUsuario
        {
            Energia = 0,
            Humor = 0,
            Apego = 0,
            Adestramento = 0,
            Brincalhao = 0
        };
    }
}