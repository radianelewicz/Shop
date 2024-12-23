namespace Shops.DAL.Migrations;

using Shops.DAL.Contexts;
using System.Data.Entity.Migrations;

internal sealed class Configuration : DbMigrationsConfiguration<ShopsContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(ShopsContext context)
    {
        context.Set<Shop>().AddRange(GetShops());
        context.SaveChanges();
    }

    private static Shop[] GetShops() =>
        [
            new Shop
            {
                ShopID = 1,
                Name = "Sklep 1",
                ShopOrders = new List<ShopOrder>()
                {
                    new ShopOrder()
                    {
                        ShopOrderID = 1,
                        ShopID = 1,
                        BruttoCost = 1,
                        City = "City 1",
                        NettoCost = 1,
                        PaymentType = PaymentTypeEnum.Cash,
                        PostalCode = "11-111",
                        ProductCode = "ProductCode 1",
                        Quantity = 1,
                        Street = "Street 1"
                    }
                }
            },
            new Shop
            {
                ShopID = 2,
                Name = "Sklep 2",
                ShopOrders = new List<ShopOrder>()
                {
                    new ShopOrder()
                    {
                        ShopOrderID = 2,
                        ShopID = 2,
                        BruttoCost = 2,
                        City = "City 2",
                        NettoCost = 2,
                        PaymentType = PaymentTypeEnum.Cash,
                        PostalCode = "22-222",
                        ProductCode = "ProductCode 2",
                        Quantity = 2,
                        Street = "Street 1"
                    },
                    new ShopOrder()
                    {
                        ShopOrderID = 3,
                        ShopID = 2,
                        BruttoCost = 3,
                        City = "City 3",
                        NettoCost = 3,
                        PaymentType = PaymentTypeEnum.Card,
                        PostalCode = "33-333",
                        ProductCode = "ProductCode 3",
                        Quantity = 3,
                        Street = "Street 3"
                    }
                }
            },
            new Shop
            {
                ShopID = 3,
                Name = "Sklep 3",
                ShopOrders = new List<ShopOrder>()
                {
                    new ShopOrder()
                    {
                        ShopOrderID = 4,
                        ShopID = 3,
                        BruttoCost = 4,
                        City = "City 4",
                        NettoCost = 4,
                        PaymentType = PaymentTypeEnum.Cash,
                        PostalCode = "44-444",
                        ProductCode = "ProductCode 4",
                        Quantity = 4,
                        Street = "Street 4"

                    },
                    new ShopOrder()
                    {
                        ShopOrderID = 5,
                        ShopID = 3,
                        BruttoCost = 5,
                        City = "City 5",
                        NettoCost = 5,
                        PaymentType = PaymentTypeEnum.Card,
                        PostalCode = "55-555",
                        ProductCode = "ProductCode 5",
                        Quantity = 5,
                        Street = "Street 5"
                    },
                    new ShopOrder()
                    {
                        ShopOrderID = 6,
                        ShopID = 3,
                        BruttoCost = 6,
                        City = "City 6",
                        NettoCost = 6,
                        PaymentType = PaymentTypeEnum.Transfer,
                        PostalCode = "66-666",
                        ProductCode = "ProductCode 6",
                        Quantity = 6,
                        Street = "Street 6"
                    }
                }
            }
        ];
}
