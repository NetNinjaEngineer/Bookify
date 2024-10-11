using AutoMapper;
using Bookify.Entities;
using Bookify.Models;
using Bookify.Repository.Contracts;
using Bookify.Services.Contracts;
using Bookify.Specifications;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bookify.Controllers;

[Authorize]
public class HomeController : Controller
{
	private readonly Guid _basketId = Guid.Parse("BD59E9A8-7B75-419B-ACCD-E68DC42DFB57");

	private readonly IGenericRepository<Book> _bookRepository;
	private readonly IGenericRepository<Genre> _genreRepository;
	private readonly IGenericRepository<Author> _authorRepository;
	private readonly IShoppingCartService _shoppingCartService;
	private readonly IMapper _mapper;

	public HomeController(IGenericRepository<Book> bookRepository,
						   IGenericRepository<Genre> genreRepository,
						   IGenericRepository<Author> authorRepository,
						   IMapper mapper,
						   IShoppingCartService shoppingCartService)
	{
		_bookRepository = bookRepository;
		_genreRepository = genreRepository;
		_authorRepository = authorRepository;
		_mapper = mapper;
		_shoppingCartService = shoppingCartService;
	}

	public async Task<IActionResult> Index()
	{
		var allBooks = await _bookRepository.GetAllAsync();

		var mappedBooks = _mapper.Map<IEnumerable<BookForListVM>>(allBooks);

		ViewBag.AllGenres = await _genreRepository.GetAllAsync();

		ViewBag.ShoppingCart = await _shoppingCartService.GetBasketAsync(_basketId);

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

	[AllowAnonymous]
	public IActionResult AboutUs()
	{
		return View();
	}

	public IActionResult ContactUs()
	{
		return View();
	}
}
