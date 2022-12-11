using System.ComponentModel.DataAnnotations;
using Microsoft.ML.Data;

namespace sistemaDeAdocaoParaAnimais.Models
{
    public class ClusterPrediction
    {
        [Key]
        public int Id { get; set; }

        [ColumnName("PredictedLabel")]
        public uint PredictedClusterId;

        [ColumnName("Score")]
        public float[] Distances;
    }
}