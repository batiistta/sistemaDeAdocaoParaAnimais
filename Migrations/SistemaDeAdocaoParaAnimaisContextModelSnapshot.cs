﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sistemaDeAdocaoParaAnimais.Models;

#nullable disable

namespace sistemaDeAdocaoParaAnimais.Migrations
{
    [DbContext(typeof(SistemaDeAdocaoParaAnimaisContext))]
    partial class SistemaDeAdocaoParaAnimaisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("sistemaDeAdocaoParaAnimais.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Castrado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(623)
                        .HasColumnType("varchar(623)");

                    b.Property<string>("Especie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EstadoAdocaoPet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FkCaracteristicaAnimal")
                        .HasColumnType("int");

                    b.Property<uint>("FkCluster")
                        .HasColumnType("int unsigned");

                    b.Property<int>("FkUsuarios")
                        .HasColumnType("int");

                    b.Property<string>("ImagensPet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Porte")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Raca")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Vacinado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Vermifugado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FkUsuarios");

                    b.ToTable("animals");
                });

            modelBuilder.Entity("sistemaDeAdocaoParaAnimais.Models.CaracteristicaAnimal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Adestramento")
                        .HasColumnType("float");

                    b.Property<float>("Apego")
                        .HasColumnType("float");

                    b.Property<float>("Brincalhao")
                        .HasColumnType("float");

                    b.Property<float>("Energia")
                        .HasColumnType("float");

                    b.Property<float>("Humor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("caracteristicaAnimals");
                });

            modelBuilder.Entity("sistemaDeAdocaoParaAnimais.Models.CaracteristicaUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Adestramento")
                        .HasColumnType("float");

                    b.Property<float>("Apego")
                        .HasColumnType("float");

                    b.Property<float>("Brincalhao")
                        .HasColumnType("float");

                    b.Property<float>("Energia")
                        .HasColumnType("float");

                    b.Property<float>("Humor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("caracteristicaUsuarios");
                });

            modelBuilder.Entity("sistemaDeAdocaoParaAnimais.Models.ClusterPrediction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("clusterPredictions");
                });

            modelBuilder.Entity("sistemaDeAdocaoParaAnimais.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("longtext");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ConfirmeEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ConfirmeSenha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DtNascimento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<uint>("FkCluster")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeSocial")
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("TermosCondições")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("complemento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("fkCaracteristica")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("sistemaDeAdocaoParaAnimais.Models.Animal", b =>
                {
                    b.HasOne("sistemaDeAdocaoParaAnimais.Models.Usuarios", "Usuarios")
                        .WithMany("Animals")
                        .HasForeignKey("FkUsuarios")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("sistemaDeAdocaoParaAnimais.Models.Usuarios", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
