﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sistemaDeAdocaoParaAnimais.Models;

#nullable disable

namespace sistemaDeAdocaoParaAnimais.Migrations
{
    [DbContext(typeof(SistemaDeAdocaoParaAnimaisContext))]
    [Migration("20221013220643_TesteL")]
    partial class TesteL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("sistemaDeAdocaoParaAnimais.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Adulto")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CaracteristicasId")
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EspeciesEspecieId")
                        .HasColumnType("int");

                    b.Property<bool>("Filhote")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("FkCaracteristica")
                        .HasColumnType("int");

                    b.Property<int>("FkEspecie")
                        .HasColumnType("int");

                    b.Property<int>("FkUsuarios")
                        .HasColumnType("int");

                    b.Property<string>("ImagensPet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Porte")
                        .HasColumnType("int");

                    b.Property<string>("Raca")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CaracteristicasId");

                    b.HasIndex("EspeciesEspecieId");

                    b.HasIndex("FkUsuarios");

                    b.ToTable("animals");
                });

            modelBuilder.Entity("sistemaDeAdocaoParaAnimais.Models.Caracteristica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Adestramento")
                        .HasColumnType("int");

                    b.Property<int>("Apego")
                        .HasColumnType("int");

                    b.Property<int>("Brincadeira")
                        .HasColumnType("int");

                    b.Property<bool>("Castrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Energia")
                        .HasColumnType("int");

                    b.Property<int>("Humor")
                        .HasColumnType("int");

                    b.Property<int>("Inteligencia")
                        .HasColumnType("int");

                    b.Property<int>("Latido")
                        .HasColumnType("int");

                    b.Property<bool>("Vacinado")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Vermifugado")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("caracteristicas");
                });

            modelBuilder.Entity("sistemaDeAdocaoParaAnimais.Models.Especie", b =>
                {
                    b.Property<int>("EspecieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("EspecieId");

                    b.ToTable("especies");
                });

            modelBuilder.Entity("sistemaDeAdocaoParaAnimais.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

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

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("TermosCondições")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("complemento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UsuarioId");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("sistemaDeAdocaoParaAnimais.Models.Animal", b =>
                {
                    b.HasOne("sistemaDeAdocaoParaAnimais.Models.Caracteristica", "Caracteristicas")
                        .WithMany("Animals")
                        .HasForeignKey("CaracteristicasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistemaDeAdocaoParaAnimais.Models.Especie", "Especies")
                        .WithMany("Animals")
                        .HasForeignKey("EspeciesEspecieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistemaDeAdocaoParaAnimais.Models.Usuarios", "Usuarios")
                        .WithMany("Animals")
                        .HasForeignKey("FkUsuarios")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caracteristicas");

                    b.Navigation("Especies");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("sistemaDeAdocaoParaAnimais.Models.Caracteristica", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("sistemaDeAdocaoParaAnimais.Models.Especie", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("sistemaDeAdocaoParaAnimais.Models.Usuarios", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
