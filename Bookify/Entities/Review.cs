using System.ComponentModel.DataAnnotations;

namespace Bookify.Entities;

public class Review : BaseEntity
{
	public string ReviewerName { get; set; } = string.Empty;
	public string ReviewDescription { get; set; } = string.Empty;
	public string ReviewerPictureName { get; set; } = string.Empty;
	public int BookId { get; set; }
	public Book Book { get; set; }
	public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
	public string UserId { get; set; }
	public User User { get; set; }
	[Range(1, 5)]
	public int RatingValue { get; set; }
}
