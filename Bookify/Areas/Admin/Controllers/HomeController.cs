using Microsoft.AspNetCore.Mvc;

namespace Bookify.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
