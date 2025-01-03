namespace CustomShop.Web.Models.EntityFramework;

public record OrderViewModel(
    int OrderId,
    string ProductCode,
    decimal NettoCost,
    decimal BruttoCost,
    int Quantity);
