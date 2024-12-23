namespace Shops.Web.DAL.DataInitialization;

internal static class DatabaseInitializer
{
    internal static void Initialize(ShopsContext shopsContext)
    {
        shopsContext.Database.EnsureCreated();

        var shopDbSet = shopsContext.Set<Shop>();

        if (shopDbSet.Any())
        {
            return;
        }

        shopsContext.Set<Shop>().AddRange(new Shop[]
        {
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
                        PaymentType = PaymentTypeEnum.Cash,
                        PostalCode = "11-111",
                        ProductCode = "ABC",
                        Street = "Aleja Jerozolimska"
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
                        City = "Gdańsk",
                        Quantity = 2,
                        BruttoCost = 123,
                        NettoCost = 126,
                        PaymentType = PaymentTypeEnum.Card,
                        PostalCode = "12-345",
                        ProductCode = "ABC",
                        Street = "Ulica w Gdańsku"
                    },
                    new ShopOrder()
                    {
                        City = "Opole",
                        Quantity = 2,
                        BruttoCost = 123,
                        NettoCost = 126,
                        PaymentType = PaymentTypeEnum.Card,
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
                        PaymentType = PaymentTypeEnum.Transfer,
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
                        PaymentType = PaymentTypeEnum.Cash,
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
                        PaymentType = PaymentTypeEnum.Cash,
                        PostalCode = "66-66",
                        ProductCode = "Buty",
                        Street = "Ulica we Wrocławiu"
                    }
                }
            }
        });

        shopsContext.SaveChanges();
    }
}
