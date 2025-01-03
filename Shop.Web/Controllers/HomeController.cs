using Microsoft.AspNetCore.Mvc;

namespace CustomShop.Web.Controllers;

public class HomeController : Controller
{
    public HomeController()
    { }

    public IActionResult Index()
    {
        return View();
    }
}
