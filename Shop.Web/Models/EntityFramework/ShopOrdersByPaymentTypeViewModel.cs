using CustomShop.Web.DAL.Models;

namespace CustomShop.Web.Models.EntityFramework;

public sealed record ShopOrdersByPaymentTypeViewModel(PaymentType PaymentType, IEnumerable<ShopOrderViewModel> ShopOrders);
