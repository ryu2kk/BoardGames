using BoardGames.Domain.Entities;
using System.Linq.Expressions;

namespace BoardGames.Application.Common.Interfaces
{
	public interface IGameRepository : IRepository<Game>
	{
		void Update(Game entity);
	}
}
