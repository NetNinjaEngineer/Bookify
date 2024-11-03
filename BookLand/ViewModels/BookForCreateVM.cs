namespace Bookify.ViewModels;

public class BookForCreateVM
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public IFormFile Image { get; set; }
    public decimal Price { get; set; }
    public int? GenreId { get; set; }
    public int? AuthorId { get; set; }
}
