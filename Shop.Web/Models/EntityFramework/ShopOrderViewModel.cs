namespace CustomShop.Web.Models.EntityFramework;

public record ShopOrderViewModel(
    int ShopOrderId,
    string ProductCode,
    decimal NettoCost,
    decimal BruttoCost,
    int Quantity,
    string Street,
    string City,
    string PostalCode);
