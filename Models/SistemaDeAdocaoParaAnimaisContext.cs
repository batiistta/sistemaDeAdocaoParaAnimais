using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Models 
{
    public class SistemaDeAdocaoParaAnimaisContext : DbContext
    {
        public SistemaDeAdocaoParaAnimaisContext(DbContextOptions<SistemaDeAdocaoParaAnimaisContext> options) : base(options){}

        public DbSet<Animal> animals { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<CaracteristicaAnimal> caracteristicaAnimals {get; set;}
        public DbSet<CaracteristicaUsuario> caracteristicaUsuarios { get; set; }
        public DbSet<ClusterPrediction> clusterPredictions { get; set; }
    }
};