namespace Bookify.Entities;

public class Author : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public ICollection<Book> Books { get; set; } = [];
}
