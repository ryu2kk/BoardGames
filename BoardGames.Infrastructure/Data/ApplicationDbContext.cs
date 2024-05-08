using BoardGames.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardGames.Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
		
		}

		public DbSet<Category> Categorys { get; set; }

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
		}
	}
}
