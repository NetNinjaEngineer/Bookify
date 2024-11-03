namespace Bookify.Entities;

public class Tag : BaseEntity
{
	public string TagName { get; set; } = string.Empty;
	public ICollection<Book> Books { get; set; } = [];
	public ICollection<BookTag> BookTags { get; set; } = [];
}