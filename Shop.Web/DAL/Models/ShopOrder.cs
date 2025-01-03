namespace CustomShop.Web.DAL.Models;

public class ShopOrder
{
    public int ShopOrderID { get; set; }
    public string ProductCode { get; set; } = null!;
    public decimal NettoCost { get; set; }
    public decimal BruttoCost { get; set; }
    public int Quantity { get; set; }
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public PaymentType PaymentType { get; set; }
    public int ShopID { get; set; }
    public Shop Shop { get; set; } = null!;
}
