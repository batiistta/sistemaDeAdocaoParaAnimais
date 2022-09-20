using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Models;
{
    public class SistemaDeAdocaoParaAnimaisContext : DbContext
    {
        public SistemaDeAdocaoParaAnimaisContext(DbContextOptions<SistemaDeAdocaoParaAnimaisContext> options) : base(options){}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }
    }
}