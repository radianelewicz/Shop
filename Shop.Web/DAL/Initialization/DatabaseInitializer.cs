using CustomShop.Web.DAL.Contexts;
using CustomShop.Web.DAL.Models;

namespace Shops.Web.DAL.DataInitialization;

internal static class DatabaseInitializer
{
    internal static void Initialize(IConfiguration configuration)
    {
        using var shopContext = new ShopContext(configuration);
        shopContext.Database.EnsureCreated();

        var shopDbSet = shopContext.Set<Shop>();

        if (shopDbSet.Any())
        {
            return;
        }

        shopContext.Set<Shop>().AddRange(
        [
            new Shop()
            {
                Name = "Sklep 1",
                ShopOrders = new List<ShopOrder>()
                {
                    new ShopOrder()
                    {
                        City = "Warszawa",
                        Quantity = 2,
                        BruttoCost = 123,
                        NettoCost = 126,
                        PaymentType = PaymentType.Cash,
                        PostalCode = "11-111",
                        ProductCode = "ABC",
                        Street = "Ulica w Gdańsku"
                    }
                }
            },
            new Shop()
            {
                Name = "Sklep 2",
                ShopOrders = new List<ShopOrder>()
                {
                    new ShopOrder()
                    {
                        City = "Warszawa",
                        Quantity = 2,
                        BruttoCost = 123,
                        NettoCost = 126,
                        PaymentType = PaymentType.Card,
                        PostalCode = "12-345",
                        ProductCode = "ABC",
                        Street = "Aleja Jerozolimska"
                    },
                    new ShopOrder()
                    {
                        City = "Opole",
                        Quantity = 2,
                        BruttoCost = 123,
                        NettoCost = 126,
                        PaymentType = PaymentType.Card,
                        PostalCode = "11-111",
                        ProductCode = "ABC",
                        Street = "Ulica w Opolu"
                    }
                }
            },
            new Shop()
            {
                Name = "Sklep 3",
                ShopOrders = new List<ShopOrder>()
                {
                    new ShopOrder()
                    {
                        City = "Warszawa",
                        Quantity = 10,
                        BruttoCost = 12314,
                        NettoCost = 51341,
                        PaymentType = PaymentType.Transfer,
                        PostalCode = "44-444",
                        ProductCode = "AAA",
                        Street = "Aleja Jerozolimska"
                    },
                    new ShopOrder()
                    {
                        City = "Białystok",
                        Quantity = 2,
                        BruttoCost = 431,
                        NettoCost = 1561,
                        PaymentType = PaymentType.Cash,
                        PostalCode = "55-555",
                        ProductCode = "Spodnie",
                        Street = "Choroszczańska"
                    },
                    new ShopOrder()
                    {
                        City = "Wrocław",
                        Quantity = 1,
                        BruttoCost = 100,
                        NettoCost = 123,
                        PaymentType = PaymentType.Cash,
                        PostalCode = "66-66",
                        ProductCode = "Buty",
                        Street = "Ulica we Wrocławiu"
                    }
                }
            }
        ]);

        shopContext.SaveChanges();
    }
}
