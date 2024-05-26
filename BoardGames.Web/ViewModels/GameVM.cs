using BoardGames.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BoardGames.Web.ViewModels
{
	public class GameVM
	{
        public Game Game { get; set; } =null!;

        [ValidateNever]
        public IEnumerable<SelectListItem>? CategoryList { get; set; }
    }
}
