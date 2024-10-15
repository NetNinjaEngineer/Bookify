using Bookify.Data;
using Bookify.Entities;
using Bookify.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Repository;

public class BookRepository(ApplicationDbContext context) : GenericRepository<Book>(context), IBookRepository
{
    public async Task<IEnumerable<Book>> GetRelatedBooksAsync(int bookId)
    {
        var existedBook = await context.Books
            .Include(x => x.Tags)
            .Include(x => x.Author)
            .Include(x => x.Publisher)
            .FirstOrDefaultAsync(x => x.Id == bookId);

        if (existedBook == null)
            return [];

        var bookTags = existedBook.Tags.Select(x => x.TagName).ToList();

        var relatedBooks = await context.Books
            .Include(x => x.Tags)
            .Include(x => x.Author)
            .Include(x => x.Publisher)
            .Where(x =>
                x.Publisher!.PublisherName.Equals(existedBook.Publisher!.PublisherName, StringComparison.CurrentCultureIgnoreCase) ||
                x.Author!.FullName.Equals(existedBook.Author!.FullName, StringComparison.CurrentCultureIgnoreCase) ||
                x.Tags.Any(tag => bookTags.Contains(tag.TagName)) ||
                x.EditionLanguage == existedBook.EditionLanguage)
            .ToListAsync();

        if (relatedBooks.Count != 0)
            return relatedBooks;

        return [];

    }
}
