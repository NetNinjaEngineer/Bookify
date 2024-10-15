using Bookify.Abstractions;
using Bookify.ViewModels;

namespace Bookify.Services.Contracts;

public interface IBookService
{
    Task<Result<IEnumerable<BookForListVM>>> GetRelatedBooksAsync(int bookId);
}
