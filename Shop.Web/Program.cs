using Microsoft.EntityFrameworkCore;
using Shops.Web.DAL;
using Shops.Web.DAL.DataInitialization;
using Shops.Web.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Services
    .BuildServiceProvider()
    .GetRequiredService<IConfiguration>()
    .GetConnectionString("ShopsContext") ?? throw new ArgumentNullException("ShopsContext");

builder.Services.AddDbContext<ShopsContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IShopsServiceApi, ShopsServiceApi>();

var app = builder.Build();

DatabaseInitializer.Initialize(
    app.Services.GetRequiredService<ShopsContext>());

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
