using System.ComponentModel.DataAnnotations.Schema;

namespace Shops.DAL;

public class ShopOrder
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ShopOrderID { get; set; }
    public string ProductCode { get; set; } = null!;
    public decimal NettoCost { get; set; }
    public decimal BruttoCost { get; set; }
    public int Quantity { get; set; }
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public PaymentTypeEnum PaymentType  { get; set; }
    [ForeignKey("Shop")]
    public int ShopID { get; set; }
    public virtual Shop Shop { get; set; } = null!;
}
