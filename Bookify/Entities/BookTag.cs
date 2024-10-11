namespace Bookify.Entities;

public class BookTag
{
	public int BookId { get; set; }
	public Book Book { get; set; } = null!;
	public int TagId { get; set; }
	public Tag Tag { get; set; } = null!;
}
