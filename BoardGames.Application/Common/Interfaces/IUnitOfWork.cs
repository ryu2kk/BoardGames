namespace BoardGames.Application.Common.Interfaces
{
	public interface IUnitOfWork
	{
		ICategoryRepository Category { get; }
		IGameRepository Game { get; }
		void Save();
	}
}
