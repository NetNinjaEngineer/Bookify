namespace Bookify.ViewModels;

public class ReviewListViewModel
{
	public string ReviewerName { get; set; } = string.Empty;
	public string ReviewDescription { get; set; } = string.Empty;
	public string ReviewerPictureUrl { get; set; } = string.Empty;
	public DateTimeOffset CreatedAt { get; set; }
	public int RatingValue { get; set; }
}
