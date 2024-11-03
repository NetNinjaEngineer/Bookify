namespace Bookify.ViewModels;

public class PaginationVM<T>
{
	public int CurrentPage { get; set; }
	public int TotalPages { get; set; }
	public int PageSize { get; set; }
	public int TotalCount { get; set; }
	public IEnumerable<T> Data { get; set; } = [];
}
