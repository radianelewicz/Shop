using CustomShop.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomShop.Web.Controllers;

public class WebServiceController : Controller
{
    private readonly IWebShopService _webShopService;

    public WebServiceController(IWebShopService webShopService)
    {
        _webShopService = webShopService;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
        => View(await _webShopService.GetAsync(cancellationToken));
}
