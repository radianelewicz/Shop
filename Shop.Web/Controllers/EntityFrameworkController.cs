using CustomShop.Web.DAL.Contexts;
using CustomShop.Web.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomShop.Web.Controllers;

public class EntityFrameworkController : Controller
{
    private readonly ShopContext _shopContext;

    public EntityFrameworkController(ShopContext shopContet)
    {
        _shopContext = shopContet;
    }

    public async Task<IActionResult> Index()
        => View((await _shopContext.Order
            .Include(x => x.ShopOrder)
            .ToListAsync())
            .GroupBy(x => x.ShopOrder.PaymentType)
            .Select(x => new OrdersByPaymentTypeViewModel(
                x.Key,
                x.Select(y => new OrderViewModel(
                    y.OrderID,
                    y.ProductCode,
                    y.NettoCost,
                    y.BruttoCost,
                    y.Quantity)))
            )
        );
}
