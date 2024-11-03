namespace Bookify.ViewModels;

public class BooksOnSaleViewModel
{
	public int Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public decimal Price { get; set; }
	public double Rating { get; set; }
	public string PictureUrl { get; set; } = string.Empty;
	public List<string> Tags { get; set; } = [];
}
