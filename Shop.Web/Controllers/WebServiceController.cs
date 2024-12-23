using Microsoft.AspNetCore.Mvc;
using Shops.Web.Services;

namespace Shops.Web.Controllers;

public class WebServiceController : Controller
{
    private readonly IShopsServiceApi _shopsServiceApi;

    public WebServiceController(IShopsServiceApi shopsServiceApi)
    {
        _shopsServiceApi = shopsServiceApi;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
        => View(await _shopsServiceApi.GetAsync(cancellationToken));
}
