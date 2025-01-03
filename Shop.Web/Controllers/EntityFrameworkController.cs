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
        => View((await _shopContext.ShopOrder
            .Where(x => x.BruttoCost > 150)
            .ToListAsync())
            .GroupBy(x => x.PaymentType)
            .Select(x => new ShopOrdersByPaymentTypeViewModel(
                x.Key,
                x.Select(y => new ShopOrderViewModel(
                    y.ShopOrderID,
                    y.ProductCode,
                    y.NettoCost,
                    y.BruttoCost,
                    y.Quantity,
                    y.Street,
                    y.City,
                    y.PostalCode)))));
}
