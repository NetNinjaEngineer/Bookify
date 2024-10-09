using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;
public class GenresController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
