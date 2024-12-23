using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shops.Web.DAL;

namespace Shops.Web.Controllers;

public class EntityFrameworkController : Controller
{
    private readonly ShopsContext _shopsContext;

    public EntityFrameworkController(ShopsContext shopsContet)
    {
        _shopsContext = shopsContet;
    }

    public async Task<IActionResult> Index()
        => View(
            await _shopsContext.ShopOrder
            .Where(x => x.BruttoCost > 150)
            .GroupBy(x => x.PaymentType)
            .ToListAsync());
}
