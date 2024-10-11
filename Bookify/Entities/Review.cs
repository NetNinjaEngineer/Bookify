namespace Bookify.Entities;

public class Review : BaseEntity
{
	public string ReviewerName { get; set; } = string.Empty;
	public string ReviewDescription { get; set; } = string.Empty;
	public string ReviewerPictureName { get; set; } = string.Empty;
	public int? BookId { get; set; }
	public Book? Book { get; set; }
}
