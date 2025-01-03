using CustomShop.Web.DAL.Models;

namespace CustomShop.Web.Models.EntityFramework;

public sealed record OrdersByPaymentTypeViewModel(PaymentType PaymentType, IEnumerable<OrderViewModel> Orders);
