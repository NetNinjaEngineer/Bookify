namespace Bookify.Entities;

public class Book : BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageName { get; set; }
    public decimal Price { get; set; }
    public int? GenreId { get; set; }
    public Genre? Genre { get; set; }
    public int? AuthorId { get; set; }
    public Author? Author { get; set; }
    public int StockQuantity { get; set; }

    public int? WishlistId { get; set; }

    public Wishlist? Wishlist { get; set; }
}
