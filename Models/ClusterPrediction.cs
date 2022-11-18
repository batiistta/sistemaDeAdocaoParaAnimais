using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Models
{
    
        public class ClusterPrediction
    {
        [ColumnName("PredictedLabel")]
        public uint PredictedClusterId;

        [ColumnName("Score")]
        public float[] Distances;
    }

    /*Essa parte peguei do cógido de Fran, não revisei se será assim ainda mas
    coloquei caso algum de vocês pesquise sobre isso antes de mim*/
    public class Result 
    {
        public ClusterPrediction clusterPrediction {get; set;}
        public Animal Animal { get; set; }
    }
    
}