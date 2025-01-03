namespace CustomShop.Web.DAL.Models;

public class ClientAddress
{
    public int ClientAddressID { get; set; }
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public int ShopOrderID { get; set; }
    public ShopOrder ShopOrder { get; set; } = null!;
}
