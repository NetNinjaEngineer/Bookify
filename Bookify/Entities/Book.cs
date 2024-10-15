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

	public string ISBN { get; set; } = string.Empty;

	public EditionLanguage EditionLanguage { get; set; }

	public string BookFormat { get; set; } = string.Empty;

	public int Pages { get; set; }

	public int Lessons { get; set; }

	public bool IsOnSale { get; set; }

	public DateTimeOffset DatePublished { get; set; } = DateTimeOffset.Now;

	public int? PublisherId { get; set; }

	public Publisher? Publisher { get; set; }

	public ICollection<Tag> Tags { get; set; } = [];

	public ICollection<BookTag> BookTags { get; set; } = [];

	public ICollection<Review> Reviews { get; set; } = [];

}