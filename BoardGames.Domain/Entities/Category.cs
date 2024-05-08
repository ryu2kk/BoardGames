using System.ComponentModel.DataAnnotations;

namespace BoardGames.Domain.Entities
{
	public class Category
	{
		public int Id {  get; set; }

		[MaxLength(100)]
		public required string Name { get; set; }

	}
}
