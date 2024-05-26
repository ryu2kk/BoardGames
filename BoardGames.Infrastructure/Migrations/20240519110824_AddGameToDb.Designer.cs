﻿// <auto-generated />
using BoardGames.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoardGames.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240519110824_AddGameToDb")]
    partial class AddGameToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BoardGames.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categorys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Strategy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Classic"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Business"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Family"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Mistery"
                        });
                });

            modelBuilder.Entity("BoardGames.Domain.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Additional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PlayerNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Additional = "Variações de tabuleiro, cartas de desenvolvimento, recursos (madeira, trigo, lã, etc.)",
                            CategoryId = 1,
                            Description = "Catan é um jogo de estratégia no qual os jogadores competem para construir colônias e expandir seu território em uma ilha fictícia.",
                            ImageUrl = "https://example.com/catan-image",
                            Name = "Catan",
                            PlayerNumber = 3
                        },
                        new
                        {
                            Id = 2,
                            Additional = "Varios modos, diferentes edições temáticas, cartas de sorte/azar.",
                            CategoryId = 3,
                            Description = "Monopólio é um jogo clássico de negociação imobiliária no qual os jogadores compram, vendem e trocam propriedades para acumular riqueza e falir os seus adversários.",
                            ImageUrl = "https://example.com/monopoly-image",
                            Name = "Monopólio",
                            PlayerNumber = 2
                        },
                        new
                        {
                            Id = 3,
                            Additional = "Tabuleiros assimétricos, cartas de objetivos, miniaturas de unidades.",
                            CategoryId = 1,
                            Description = "Scythe é um jogo de estratégia ambientado em uma realidade alternativa dos anos 1920, onde os jogadores controlam facções e competem pela supremacia em uma terra devastada pela guerra.",
                            ImageUrl = "https://example.com/scythe-image",
                            Name = "Scythe",
                            PlayerNumber = 1
                        });
                });

            modelBuilder.Entity("BoardGames.Domain.Entities.Game", b =>
                {
                    b.HasOne("BoardGames.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
