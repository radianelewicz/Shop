using System.Data.Entity;

namespace Shops.DAL.Contexts;

public class ShopsContext : DbContext
{
    public ShopsContext() : base("ConnectionStrings:ShopsContext")
    {

    }

    public DbSet<Shop> Shop { get; set; } = null!;
    public DbSet<ShopOrder> ShopOrder { get; set; } = null!;
}
