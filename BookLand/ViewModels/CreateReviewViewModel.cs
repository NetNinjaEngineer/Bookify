using System.ComponentModel.DataAnnotations;

namespace Bookify.ViewModels;

public class CreateReviewViewModel
{
	[Required]
	public int BookId { get; set; }

	[Required]
	public string UserEmail { get; set; }

	[Required]
	public string ReviewerName { get; set; } = string.Empty;

	[Required]
	public string ReviewerPictureName { get; set; } = string.Empty;

	[Required]
	public string ReviewDescription { get; set; } = string.Empty;

	[Range(1, 5)]
	public int RatingValue { get; set; }

}
