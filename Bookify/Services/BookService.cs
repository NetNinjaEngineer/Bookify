using AutoMapper;
using Bookify.Abstractions;
using Bookify.Repository.Contracts;
using Bookify.Services.Contracts;
using Bookify.ViewModels;

namespace Bookify.Services;

public class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
{
	public async Task<IEnumerable<BookForListVM>> GetBooksInSpecificTag(int tagId)
	{
		return mapper.Map<IEnumerable<BookForListVM>>(
			await bookRepository.GetBooksByTagAsync(tagId)
			);
	}

	public async Task<IEnumerable<BooksOnSaleViewModel>> GetOnSaleBooks()
	{
		return await bookRepository.GetAllBooksOnSaleAsync();
	}

	public async Task<Result<IEnumerable<BookForListVM>>> GetRelatedBooksAsync(int bookId)
	{
		var relatedBooks = await bookRepository.GetRelatedBooksAsync(bookId);

		if (relatedBooks.Any())
		{
			var mappedBooks = mapper.Map<IEnumerable<BookForListVM>>(relatedBooks);
			return Result<IEnumerable<BookForListVM>>.Ok(mappedBooks);
		}

		return Result<IEnumerable<BookForListVM>>.Ok([]);
	}
}
