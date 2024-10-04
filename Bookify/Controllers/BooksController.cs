using AutoMapper;
using Bookify.Entities;
using Bookify.Repository.Contracts;
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
        return View(allBooks);
    }


}
