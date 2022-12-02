using System.ComponentModel.DataAnnotations;
using Microsoft.ML.Data;

namespace sistemaDeAdocaoParaAnimais.Models
{
    public static class CaracteristicaUsuarioTeste
    {
        internal static readonly CaracteristicaUsuario Setosa = new CaracteristicaUsuario
        {
            Energia = 3.1f,
            Humor = 2.5f,
            Apego = 0.4f
        };
    }
}