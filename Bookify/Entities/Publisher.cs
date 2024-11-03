namespace Bookify.Entities;

public class Publisher : BaseEntity
{
	public string PublisherName { get; set; } = string.Empty;
	public ICollection<Book> Books { get; set; } = [];
}
