namespace Bookify.Views.ViewModels;

public class BookForListVM
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageName { get; set; }
    public decimal Price { get; set; }
    public string Genre { get; set; }
    public string Author { get; set; }
}
