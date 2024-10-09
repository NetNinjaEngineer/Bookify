using AutoMapper;
using Bookify.Entities;
using Bookify.Models;
using Bookify.Repository.Contracts;
using Bookify.Specifications;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bookify.Controllers;
public class HomeController : Controller
{
	private readonly IGenericRepository<Book> _bookRepository;
	private readonly IGenericRepository<Genre> _genreRepository;
	private readonly IGenericRepository<Author> _authorRepository;
	private readonly IMapper _mapper;

	public HomeController(IGenericRepository<Book> bookRepository,
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
		ViewBag.AllGenres = await _genreRepository.GetAllAsync();
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




	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}

	[Route("Home/Error404")]
	public IActionResult Error404()
	{
		return View();
	}

	public async Task<IActionResult> GetBooksWithRelatedGenre(int id)
	{
		var getBooksWithGenreSpecification = new GetAllBooksWithSpecifiedGenreSpecification();
		var booksWithRelatedGenre = await _bookRepository.GetAllWithSpecificationAsync(getBooksWithGenreSpecification);
		var result = booksWithRelatedGenre.Where(x => x.GenreId == id).ToList();
		var mappedResult = _mapper.Map<IEnumerable<BookForListVM>>(result);
		return View(mappedResult);
	}

	public IActionResult AboutUs()
	{
		return View();
	}


	public IActionResult ContactUs()
	{
		return View();
	}
}
