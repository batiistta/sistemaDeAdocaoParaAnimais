using System.ComponentModel.DataAnnotations;
using Microsoft.ML.Data;

namespace sistemaDeAdocaoParaAnimais.Models
{
    public static class CaracteristicaUsuarioTeste
    {
        internal static readonly CaracteristicaUsuario Setosa = new CaracteristicaUsuario
        {
            Energia = 0,
            Humor = 0,
            Apego = 0
        };
    }
}