﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokeliga.Api.Infra;

#nullable disable

namespace Pokeliga.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pokeliga.Api.Entities.GlcBadges", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Badge1")
                        .HasColumnType("bit");

                    b.Property<int>("Badge10")
                        .HasColumnType("int");

                    b.Property<int>("Badge2")
                        .HasColumnType("int");

                    b.Property<int>("Badge3")
                        .HasColumnType("int");

                    b.Property<int>("Badge4")
                        .HasColumnType("int");

                    b.Property<int>("Badge5")
                        .HasColumnType("int");

                    b.Property<int>("Badge6")
                        .HasColumnType("int");

                    b.Property<int>("Badge7")
                        .HasColumnType("int");

                    b.Property<int>("Badge8")
                        .HasColumnType("int");

                    b.Property<int>("Badge9")
                        .HasColumnType("int");

                    b.Property<int>("IdPokemon")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastWinDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("GlcBadges", (string)null);
                });

            modelBuilder.Entity("Pokeliga.Api.Entities.Ligas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Finalizada")
                        .HasColumnType("bit");

                    b.Property<int>("IdOrganizador")
                        .HasColumnType("int");

                    b.Property<string>("Organizador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ligas", (string)null);
                });

            modelBuilder.Entity("Pokeliga.Api.Entities.Partidas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLiga")
                        .HasColumnType("int");

                    b.Property<int>("Outcome")
                        .HasColumnType("int");

                    b.Property<int>("Player1")
                        .HasColumnType("int");

                    b.Property<int>("Player2")
                        .HasColumnType("int");

                    b.Property<int>("RoundNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdLiga");

                    b.ToTable("Partidas", (string)null);
                });

            modelBuilder.Entity("Pokeliga.Api.Entities.Players", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPokemon")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players", (string)null);
                });

            modelBuilder.Entity("Pokeliga.Api.Entities.Resultados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLiga")
                        .HasColumnType("int");

                    b.Property<int>("IdPokemon")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pontos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdLiga");

                    b.ToTable("Resultados", (string)null);
                });

            modelBuilder.Entity("Pokeliga.Api.Entities.Standins", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Derrotas")
                        .HasColumnType("int");

                    b.Property<int>("Empates")
                        .HasColumnType("int");

                    b.Property<int>("IdLiga")
                        .HasColumnType("int");

                    b.Property<int>("IdPokemon")
                        .HasColumnType("int");

                    b.Property<int>("Place")
                        .HasColumnType("int");

                    b.Property<int>("Vitorias")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdLiga");

                    b.ToTable("Standins", (string)null);
                });

            modelBuilder.Entity("Pokeliga.Api.Entities.Partidas", b =>
                {
                    b.HasOne("Pokeliga.Api.Entities.Ligas", null)
                        .WithMany()
                        .HasForeignKey("IdLiga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pokeliga.Api.Entities.Resultados", b =>
                {
                    b.HasOne("Pokeliga.Api.Entities.Ligas", null)
                        .WithMany()
                        .HasForeignKey("IdLiga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pokeliga.Api.Entities.Standins", b =>
                {
                    b.HasOne("Pokeliga.Api.Entities.Ligas", null)
                        .WithMany()
                        .HasForeignKey("IdLiga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
