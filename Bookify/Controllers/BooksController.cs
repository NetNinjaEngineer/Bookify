using AutoMapper;
using Bookify.Entities;
using Bookify.Repository.Contracts;
using Bookify.Specifications;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;
public class BooksController : Controller
{
	private readonly IGenericRepository<Book> _bookRepository;
	private readonly IGenericRepository<Genre> _genreRepository;
	private readonly IGenericRepository<Author> _authorRepository;
	private readonly IMapper _mapper;

	public BooksController(IGenericRepository<Book> bookRepository,
						   IGenericRepository<Genre> genreRepository,
						   IGenericRepository<Author> authorRepository,
						   IMapper mapper)
	{
		_bookRepository = bookRepository;
		_genreRepository = genreRepository;
		_authorRepository = authorRepository;
		_mapper = mapper;
	}

	public async Task<IActionResult> Index()
	{
		var allBooks = await _bookRepository.GetAllAsync();
		var mappedBooks = _mapper.Map<IEnumerable<BookForListVM>>(allBooks);
		return View(mappedBooks);
	}

	public async Task<IActionResult> Details(int id)
	{
		var existedBook = await _bookRepository.GetByIdAsync(id);
		if (existedBook == null)
			return NotFound();

		var mappedBook = _mapper.Map<BookForListVM>(existedBook);
		return View(mappedBook);
	}

	[HttpPost]
	public async Task<IActionResult> SearchBooks(string searchTerm)
	{
		var spec = new GetAllBooksWithGenresAndAuthorsSpecification(searchTerm);
		var searchedBooks = await _bookRepository.GetAllWithSpecificationAsync(spec);
		var mappedBooks = _mapper.Map<IEnumerable<BookForListVM>>(searchedBooks).ToList();
		return Ok(mappedBooks);
	}


}
