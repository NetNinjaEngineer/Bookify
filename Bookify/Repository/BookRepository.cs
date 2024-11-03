using Bookify.Data;
using Bookify.Entities;
using Bookify.Repository.Contracts;
using Bookify.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Repository;

public class BookRepository(
	ApplicationDbContext context,
	IHttpContextAccessor httpContext,
	IConfiguration configuration) : GenericRepository<Book>(context), IBookRepository
{
	public async Task<IEnumerable<BooksOnSaleViewModel>> GetAllBooksOnSaleAsync()
	{
		var onSaleBooks = context.Books.Join(
				context.BookTags,
				book => book.Id,
				bookTag => bookTag.BookId,
				(book, bookTag) => new { book, bookTag })
			.Join(
				context.Tags,
				bookTags => bookTags.bookTag.TagId,
				tag => tag.Id,
				(bookTags, tag) => new { bookTags, tag })
			.Join(
				context.Reviews,
				book => book.bookTags.book.Id,
				review => review.BookId,
				(book, review) => new { book, review })
			.Where(x => x.book.bookTags.book.IsOnSale)
			.GroupBy(
				key => new { key.book.bookTags.book.Title, key.book.bookTags.book.Price })
			.Select(onSaleProducts => new BooksOnSaleViewModel
			{
				Id = onSaleProducts.Select(x => x.book.bookTags.book.Id).FirstOrDefault(),
				Title = onSaleProducts.Select(OnSale => OnSale.book.bookTags.book.Title).FirstOrDefault()!,
				Price = onSaleProducts.Select(OnSale => OnSale.book.bookTags.book.Price).FirstOrDefault(),
				Rating = onSaleProducts.Average(x => x.review.RatingValue),
				Tags = onSaleProducts.Select(x => x.book.tag.TagName).Distinct().ToList(),
				PictureUrl = httpContext.HttpContext.Request.IsHttps ?
					$"{configuration["BaseUrl"]}/Files/Images/{Uri.EscapeDataString(onSaleProducts.Select(x => x.book.bookTags.book.ImageName).FirstOrDefault())}" :
					$"{configuration["FullbackUrl"]}/Files/Images/{Uri.EscapeDataString(onSaleProducts.Select(x => x.book.bookTags.book.ImageName).FirstOrDefault())}"

			});

		return onSaleBooks;
	}

	public async Task<IEnumerable<Book>> GetBooksByTagAsync(int tagId)
	{
		var booksSpecificTag = await context.Books.Join(
				context.BookTags,
				book => book.Id,
				bookTag => bookTag.BookId,
				(book, bookTag) => new { book, bookTag })
			.Join(
				context.Tags,
				combinedBookWithBookTags => combinedBookWithBookTags.bookTag.TagId,
				tag => tag.Id,
				(combinedBookWithBookTags, tag) => new { combinedBookWithBookTags, tag })
			.Where(combined => combined.tag.Id == tagId)
			.Select(booksSpecificTag => new Book
			{
				Id = booksSpecificTag.combinedBookWithBookTags.book.Id,
				ImageName = booksSpecificTag.combinedBookWithBookTags.book.ImageName,
				IsOnSale = booksSpecificTag.combinedBookWithBookTags.book.IsOnSale,
				BookFormat = booksSpecificTag.combinedBookWithBookTags.book.BookFormat,
				Description = booksSpecificTag.combinedBookWithBookTags.book.Description,
				EditionLanguage = booksSpecificTag.combinedBookWithBookTags.book.EditionLanguage,
				DatePublished = booksSpecificTag.combinedBookWithBookTags.book.DatePublished,
				Price = booksSpecificTag.combinedBookWithBookTags.book.Price
			}).ToListAsync();

		return booksSpecificTag;

	}

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

		var relatedBooks = context.Books
			.Include(x => x.Tags)
			.Include(x => x.Author)
			.Include(x => x.Publisher)
			.Where(x =>
				(
					x.Author!.FirstName == existedBook.Author!.FirstName ||
					x.Publisher!.PublisherName == existedBook.Publisher!.PublisherName ||
					x.Tags.Any(tag => bookTags.Contains(tag.TagName))
				) && x.Id != existedBook.Id)
			.ToList();

		if (relatedBooks.Count != 0)
			return relatedBooks;

		return [];

	}
}
