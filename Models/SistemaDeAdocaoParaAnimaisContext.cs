using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sistemaDeAdocaoParaAnimais.Models;

namespace sistemaDeAdocaoParaAnimais.Models;
{
    public class ProjetoRhContext : DbContext
    {
        public ProjetoRhContext(DbContextOptions<SistemaDeAdocaoParaAnimaisContext> options) : base(options){}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }
    }
}