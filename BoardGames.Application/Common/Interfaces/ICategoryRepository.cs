using BoardGames.Domain.Entities;
using System.Linq.Expressions;

namespace BoardGames.Application.Common.Interfaces
{
	public interface ICategoryRepository : IRepository<Category>
	{
		void Update(Category entity);
	}
}
