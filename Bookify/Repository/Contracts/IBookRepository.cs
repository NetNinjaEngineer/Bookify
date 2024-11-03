using Bookify.Entities;
using Bookify.ViewModels;

namespace Bookify.Repository.Contracts;

public interface IBookRepository : IGenericRepository<Book>
{
	Task<IEnumerable<Book>> GetRelatedBooksAsync(int bookId);
	Task<IEnumerable<BooksOnSaleViewModel>> GetAllBooksOnSaleAsync();

	Task<IEnumerable<Book>> GetBooksByTagAsync(int tagId);
}
