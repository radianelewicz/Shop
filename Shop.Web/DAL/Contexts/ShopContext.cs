using CustomShop.Web.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomShop.Web.DAL.Contexts;

public class ShopContext : DbContext //najlepiej oddzielny projekt i zarzadzanie migracjami
{
    private readonly string _connectionString;

    public ShopContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ShopsContext")
            ?? throw new ArgumentNullException("ShopsContext");
    }

    public DbSet<Shop> Shop { get; set; } = null!;
    public DbSet<ShopOrder> ShopOrder { get; set; } = null!;
    public DbSet<Order> Order { get; set; } = null!;
    public DbSet<ClientAddress> ClientAddress { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");

        modelBuilder.Entity<Shop>()
            .ToTable(nameof(Shop))
            .HasMany(x => x.ShopOrders)
            .WithOne(x => x.Shop)
            .HasForeignKey(x => x.ShopID)
            .IsRequired();

        modelBuilder.Entity<ShopOrder>()
            .ToTable(nameof(ShopOrder))
            .HasOne(x => x.Shop)
            .WithMany(x => x.ShopOrders)
            .HasForeignKey(x => x.ShopID)
            .IsRequired();

        modelBuilder.Entity<Order>()
            .ToTable(nameof(Order))
            .HasOne(x => x.ShopOrder)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.ShopOrderID)
            .IsRequired();

        modelBuilder.Entity<ClientAddress>()
            .ToTable(nameof(ClientAddress))
            .HasOne(x => x.ShopOrder)
            .WithOne(x => x.ClientAddress)
            .HasForeignKey<ClientAddress>(x => x.ShopOrderID)
            .IsRequired();


        base.OnModelCreating(modelBuilder);
    }
}
