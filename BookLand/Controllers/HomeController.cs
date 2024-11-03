using AutoMapper;
using Bookify.Entities;
using Bookify.Helpers;
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
    private readonly Guid _basketId;

    private readonly IGenericRepository<Book> _bookRepository;
    private readonly IGenericRepository<Genre> _genreRepository;
    private readonly IGenericRepository<Author> _authorRepository;
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;
    private readonly IEmailService _emailService;

    public HomeController(IGenericRepository<Book> bookRepository,
                           IGenericRepository<Genre> genreRepository,
                           IGenericRepository<Author> authorRepository,
                           IMapper mapper,
                           IShoppingCartService shoppingCartService,
                           IConfiguration config,
                           IEmailService emailService)
    {
        _bookRepository = bookRepository;
        _genreRepository = genreRepository;
        _authorRepository = authorRepository;
        _mapper = mapper;
        _shoppingCartService = shoppingCartService;
        _config = config;
        _basketId = Guid.Parse(_config["shoppingCartKey"]!);
        _emailService = emailService;
    }

    public async Task<IActionResult> Index()
    {
        var allBooks = await _bookRepository.GetAllAsync();

        var mappedBooks = _mapper.Map<IEnumerable<BookForListVM>>(allBooks);

        ViewBag.AllGenres = await _genreRepository.GetAllAsync();

        var basketResult = await _shoppingCartService.GetBasketAsync(_basketId);

        if (basketResult.IsSuccess)
            ViewBag.ShoppingCart = basketResult.Value;

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


    [HttpPost]
    public async Task<IActionResult> ContactUs(ContactUsModel model)
    {
        if (ModelState.IsValid)
        {
            var email = new Email
            {
                To = _config["ContactUsEmail"]!,
                Subject = "New Contact Us Submission",
                Body = GenerateEmailBody(model)
            };

            await _emailService.SendEmailAsync(email);

        }

        return View(model);
    }

    private string GenerateEmailBody(ContactUsModel model)
    {
        return $"Contact Us Form Submission\n\nFull Name: {model.FullName}\nEmail Address: {model.Email}\nPhone Number: {model.Phone}\nMessage:\n{model.Message}";
    }

    public IActionResult ThankYou()
    {
        return View();
    }
}
