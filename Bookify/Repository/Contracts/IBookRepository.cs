using Bookify.Entities;

namespace Bookify.Repository.Contracts;

public interface IBookRepository : IGenericRepository<Book>
{
    Task<IEnumerable<Book>> GetRelatedBooksAsync(int bookId);
}
