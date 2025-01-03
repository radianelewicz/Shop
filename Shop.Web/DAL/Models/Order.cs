namespace CustomShop.Web.DAL.Models;

public class Order
{
    public int OrderID { get; set; }
    public string ProductCode { get; set; } = null!;
    public decimal NettoCost { get; set; }
    public decimal BruttoCost { get; set; }
    public int Quantity { get; set; }
    public int ShopOrderID { get; set; }
    public ShopOrder ShopOrder { get; set; } = null!;
}
