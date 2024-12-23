using Microsoft.EntityFrameworkCore;

namespace Shops.Web.DAL;

public class ShopsContext : DbContext
{
    public ShopsContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Shop> Shop { get; set; } = null!;
    public DbSet<ShopOrder> ShopOrder { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");

        modelBuilder.Entity<Shop>()
            .ToTable(nameof(Shop))
            .HasMany(x => x.ShopOrders)
            .WithOne(x => x.Shop)
            .HasForeignKey(x => x.ShopOrderID);

        modelBuilder.Entity<ShopOrder>()
            .ToTable(nameof(ShopOrder))
            .HasOne(x => x.Shop)
            .WithMany()
            .HasForeignKey(x => x.ShopID);

        base.OnModelCreating(modelBuilder);
    }
}
