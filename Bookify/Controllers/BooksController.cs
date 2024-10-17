using AutoMapper;
using Bookify.Entities;
using Bookify.Repository.Contracts;
using Bookify.Services.Contracts;
using Bookify.Specifications;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;
public class BooksController : Controller
{
    private readonly IGenericRepository<Book> _bookRepository;
    private readonly IGenericRepository<Genre> _genreRepository;
    private readonly IGenericRepository<Author> _authorRepository;
    private readonly IMapper _mapper;
    private readonly IBookService _bookService;

    public BooksController(IGenericRepository<Book> bookRepository,
                           IGenericRepository<Genre> genreRepository,
                           IGenericRepository<Author> authorRepository,
                           IMapper mapper,
                           IBookService bookService)
    {
        _bookRepository = bookRepository;
        _genreRepository = genreRepository;
        _authorRepository = authorRepository;
        _mapper = mapper;
        _bookService = bookService;
    }

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5)
    {
        // get total count
        var totalCount = (await _bookRepository.GetAllAsync()).Count();

        var specification = new GetAllBooksWithRelatedDataSpecification(pageNumber, pageSize);

        var allBooks = await _bookRepository.GetAllWithSpecificationAsync(specification);

        var mappedBooks = _mapper.Map<IEnumerable<BookForListVM>>(allBooks);

        var paginationModel = new PaginationVM<BookForListVM>
        {
            CurrentPage = pageNumber,
            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize),
            PageSize = pageSize,
            TotalCount = totalCount,
            Data = mappedBooks
        };

        return View(paginationModel);
    }

    [Authorize]
    public async Task<IActionResult> Details(int id)
    {
        var specification = new GetAllBooksWithRelatedDataSpecification(id);
        var existedBook = await _bookRepository.GetEntityBySpecificationAsync(specification);
        if (existedBook == null)
            return NotFound();

        var mappedBook = _mapper.Map<BookForListVM>(existedBook);
        return View(mappedBook);
    }

    [HttpGet]
    public async Task<IActionResult> SearchBooks(string searchTerm)
    {
        var spec = new GetAllBooksWithGenresAndAuthorsSpecification(searchTerm);
        var searchedBooks = await _bookRepository.GetAllWithSpecificationAsync(spec);
        var mappedBooks = _mapper.Map<IEnumerable<BookForListVM>>(searchedBooks).ToList();
        return Ok(mappedBooks);
    }

    [HttpGet]
    public async Task<IActionResult> GetBooksInSpecificTag(int tagId)
    {
        var booksInTag = await _bookService.GetBooksInSpecificTag(tagId);
        return View(booksInTag);
    }


}
