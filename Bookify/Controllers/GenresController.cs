using AutoMapper;
using Bookify.Entities;
using Bookify.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;
public class GenresController : Controller
{
	private readonly IMapper _mapper;
	private readonly IGenericRepository<Genre> _genresRepository;

	public GenresController(
		IMapper mapper,
		IGenericRepository<Genre> genresRepository)
	{
		_mapper = mapper;
		_genresRepository = genresRepository;
	}

	public async Task<IActionResult> Index()
	{
		var genres = await _genresRepository.GetAllAsync();
		return View(genres);
	}
}
