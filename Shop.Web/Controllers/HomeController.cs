using Microsoft.AspNetCore.Mvc;
using Shops.Web.DAL;

namespace Shop.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ShopsContext _shopContext;

    public HomeController(ILogger<HomeController> logger,
        ShopsContext shopsContext)
    {
        _logger = logger;
        _shopContext = shopsContext;
    }

    public IActionResult Index()
    {
        return View();
    }
}
