using BoardGames.Application.Common.Interfaces;
using BoardGames.Infrastructure.Data;

namespace BoardGames.Infrastructure.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _db;
		public ICategoryRepository Category {  get; private set; }
		public IGameRepository Game { get; private set; }

		public UnitOfWork(ApplicationDbContext db) 
		{
			_db = db;
			Category = new CategoryRepository(db);
			Game = new GameRepository(db);
		}

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
