namespace CustomShop.Web.DAL.Models;

public class ShopOrder
{
    public int ShopOrderID { get; set; }
    public PaymentType PaymentType { get; set; }
    public int ShopID { get; set; }
    public Shop Shop { get; set; } = null!;
    public ICollection<Order> Orders { get; set; } = null!;
    public ClientAddress ClientAddress { get; set; } = null!;
}
