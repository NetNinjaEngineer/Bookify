namespace Bookify.Entities;

public class Genre : BaseEntity
{
    public string? GenreName { get; set; }
    public ICollection<Book> Books { get; set; } = [];
}
