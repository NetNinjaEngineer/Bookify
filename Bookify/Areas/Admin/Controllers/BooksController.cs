using AutoMapper;
using Bookify.Entities;
using Bookify.Helpers;
using Bookify.Repository.Contracts;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Areas.Admin.Controllers;

[Area("Admin")]
public class BooksController : Controller
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Book> _bookRepository;
    private readonly IGenericRepository<Genre> _genreRepository;
    private readonly IGenericRepository<Author> _authorRepository;

    public BooksController(
        IMapper mapper,
        IGenericRepository<Book> bookRepository,
        IGenericRepository<Genre> genreRepository,
        IGenericRepository<Author> authorRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _genreRepository = genreRepository;
        _authorRepository = authorRepository;
    }

    public async Task<IActionResult> Index()
    {
        var allBooks = await _bookRepository.GetAllAsync();
        return View(allBooks);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Genres = await _genreRepository.GetAllAsync();

        var authors = await _authorRepository.GetAllAsync();

        var authorsVM = authors.Select(x => new AuthorVM
        {
            Id = x.Id,
            FullName = $"{x.FirstName} {x.LastName}"
        });

        ViewBag.Authors = authorsVM;

        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([FromForm] BookForCreateVM bookForCreation)
    {
        var mappedBook = _mapper.Map<Book>(bookForCreation);

        if (mappedBook != null)
        {
            mappedBook.ImageName = Utility.UploadFile(bookForCreation.Image, "Images");
            _bookRepository.Add(mappedBook);

            return RedirectToAction(nameof(Index));
        }

        return View(bookForCreation);

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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ConfirmDelete(int id)
    {
        var existedBook = await _bookRepository.GetByIdAsync(id);
        if (existedBook is null)
            return NotFound();

        _bookRepository.Delete(existedBook);

        return RedirectToAction(nameof(Index));

    }
}
