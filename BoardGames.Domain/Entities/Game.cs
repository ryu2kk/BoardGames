using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGames.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }

        [ForeignKey("Category")]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; } = null!;

        public string? Description { get; set; }

        [Display(Name = "Number of Players")]
        [Range(1, 20)]
        public int PlayerNumber { get; set; }

		[NotMapped]
		public IFormFile? Image { get; set; }

		[Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        public string? Additional { get; set; }
    }
}
