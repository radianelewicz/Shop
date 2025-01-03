namespace CustomShop.Web.DAL.Models;

public class Shop
{
    public int ShopID { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<ShopOrder> ShopOrders { get; set; } = null!;
}
