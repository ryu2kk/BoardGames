using BoardGames.Application.Common.Interfaces;
using BoardGames.Domain.Entities;
using BoardGames.Infrastructure.Data;

namespace BoardGames.Infrastructure.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly ApplicationDbContext _db;

		public CategoryRepository(ApplicationDbContext db) :base(db)
		{
			_db = db;
		}

		public void Update(Category entity)
		{
			_db.Update(entity);
		}
	}
}
