using BoardGames.Application.Common.Interfaces;
using BoardGames.Domain.Entities;
using BoardGames.Infrastructure.Data;

namespace BoardGames.Infrastructure.Repository
{
	public class GameRepository : Repository<Game>, IGameRepository
	{
		private readonly ApplicationDbContext _db;

		public GameRepository(ApplicationDbContext db) :base(db)
		{
			_db = db;
		}

		public void Update(Game entity)
		{
			_db.Update(entity);
		}
	}
}
