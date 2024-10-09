using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;
public class WishlistController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
