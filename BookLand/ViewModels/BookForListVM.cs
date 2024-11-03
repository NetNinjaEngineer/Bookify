using Bookify.Entities;

namespace Bookify.ViewModels;

public class BookForListVM
{
	public int Id { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
	public string? PictureUrl { get; set; }
	public decimal Price { get; set; }
	public string Genre { get; set; } = string.Empty;
	public string Author { get; set; } = string.Empty;
	public string Publisher { get; set; } = string.Empty;
	public string ISBN { get; set; } = string.Empty;

	public EditionLanguage EditionLanguage { get; set; }

	public string BookFormat { get; set; } = string.Empty;

	public int Pages { get; set; }

	public int Lessons { get; set; }

	public DateTimeOffset DatePublished { get; set; }

	public ICollection<TagVM> Tags { get; set; } = [];

	public ICollection<ReviewListViewModel> Reviews { get; set; } = [];

	public CreateReviewViewModel CreateReviewViewModel { get; set; } = new();
}
