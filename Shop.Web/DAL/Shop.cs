using System.ComponentModel.DataAnnotations.Schema;

namespace Shops.Web.DAL;

public class Shop
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ShopID { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<ShopOrder> ShopOrders { get; set; } = null!;
}
