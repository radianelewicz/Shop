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
                        ClientAddress = new ClientAddress()
                        {
                            PostalCode = "11-111",
                            Street = "Ulica w Gdańsku",
                            City = "Warszawa",
                        },
                        Orders = new List<Order>()
                        {
                            new Order()
                            {
                                Quantity = 2,
                                BruttoCost = 123,
                                NettoCost = 126,
                                ProductCode = "ABC",
                            }
                        },
                        PaymentType = PaymentType.Cash,
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
                        ClientAddress = new ClientAddress()
                        {
                            City = "Warszawa",
                            Street = "Aleja Jerozolimska",
                            PostalCode = "12-345",
                        },
                        Orders = new List<Order>()
                        {
                            new Order()
                            {
                                Quantity = 2,
                                BruttoCost = 123,
                                NettoCost = 126,
                                ProductCode = "ABC",
                            }
                        },
                        PaymentType = PaymentType.Card,                   
                    },
                    new ShopOrder()
                    {
                        ClientAddress = new ClientAddress()
                        {
                                City = "Opole",
                                PostalCode = "11-111",
                                Street = "Ulica w Opolu"
                        },
                        Orders = new List<Order>()
                        {
                            new Order()
                            {
                                Quantity = 2,
                                BruttoCost = 123,
                                NettoCost = 126,
                                ProductCode = "ABC",
                            }
                        },
                        PaymentType = PaymentType.Card,
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
                        ClientAddress = new ClientAddress()
                        {
                                City = "Warszawa",
                                PostalCode = "44-444",
                                Street = "Aleja Jerozolimska"
                        },
                        Orders = new List<Order>()
                        {
                            new Order()
                            {
                                Quantity = 10,
                                BruttoCost = 12314,
                                NettoCost = 51341,
                                ProductCode = "AAA",
                            }
                        },
                        PaymentType = PaymentType.Transfer,
                    },
                    new ShopOrder()
                    {
                        ClientAddress = new ClientAddress()
                        {
                            City = "Białystok",
                            PostalCode = "55-555",
                            Street = "Choroszczańska"
                        },
                        Orders = new List<Order>()
                        {
                            new Order()
                            {
                                Quantity = 2,
                                BruttoCost = 431,
                                NettoCost = 1561,
                                ProductCode = "Spodnie",
                            },
                            new Order()
                            {
                                Quantity = 1,
                                BruttoCost = 100,
                                NettoCost = 123,
                                ProductCode = "Buty",
                            }
                        },
                        PaymentType = PaymentType.Cash,
                    },
                }
            }
        ]);

        shopContext.SaveChanges();
    }
}
