using Bookify.Abstractions;
using Bookify.ViewModels;

namespace Bookify.Services.Contracts;

public interface IBookService
{
	Task<Result<IEnumerable<BookForListVM>>> GetRelatedBooksAsync(int bookId);
	Task<IEnumerable<BooksOnSaleViewModel>> GetOnSaleBooks();
	Task<IEnumerable<BookForListVM>> GetBooksInSpecificTag(int tagId);
}
