using BoardGames.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardGames.Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
		
		}

		public DbSet<Category> Categorys { get; set; }
		public DbSet<Game> Games { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Category>().HasData(
				 new Category
				 { 
					Id = 1,
					Name = "Strategy",
				 },

				 new Category
				 {
					 Id = 2,
					 Name = "Classic",
				 },

				 new Category
				 {
					 Id = 3,
					 Name = "Business",
				 },

				 new Category
				 {
					 Id = 4,
					 Name = "Family",
				 },

				 new Category
				 {
					 Id = 5,
					 Name = "Mistery",
				 }
			);

		           modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Name = "Catan",
                    CategoryId = 1,
                    Description = "Catan é um jogo de estratégia no qual os jogadores competem para construir colônias e expandir seu território em uma ilha fictícia.",
                    PlayerNumber = 3,
                    ImageUrl = "https://example.com/catan-image",
                    Additional = "Variações de tabuleiro, cartas de desenvolvimento, recursos (madeira, trigo, lã, etc.)"
                },

                new Game
                {
                    Id = 2,
                    Name = "Monopólio",
                    CategoryId = 3,
                    Description = "Monopólio é um jogo clássico de negociação imobiliária no qual os jogadores compram, vendem e trocam propriedades para acumular riqueza e falir os seus adversários.",
                    PlayerNumber = 2,
                    ImageUrl = "https://example.com/monopoly-image",
                    Additional = "Varios modos, diferentes edições temáticas, cartas de sorte/azar."
                },

                new Game
                {
                    Id = 3,
                    Name = "Scythe",
                    CategoryId = 1,
                    Description = "Scythe é um jogo de estratégia ambientado em uma realidade alternativa dos anos 1920, onde os jogadores controlam facções e competem pela supremacia em uma terra devastada pela guerra.",
                    PlayerNumber = 1,
                    ImageUrl = "https://example.com/scythe-image",
                    Additional = "Tabuleiros assimétricos, cartas de objetivos, miniaturas de unidades."
                }
            );
		}
	}
}
