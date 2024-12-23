using Shops.Web.Models;

namespace Shops.Web.Services;

public interface IShopsServiceApi
{
    public Task<IEnumerable<ServiceShopOrderViewModel>> GetAsync(CancellationToken cancellationToken);
}

public class ShopsServiceApi : IShopsServiceApi
{
    const string _apiUrl = "https://localhost:7050/ShopOrder";

    public async Task<IEnumerable<ServiceShopOrderViewModel>> GetAsync(CancellationToken cancellationToken)
    {
        var httpClient = new HttpClient();
        var result = await httpClient.GetFromJsonAsync<IEnumerable<ServiceShopOrderViewModel>>(
            string.Concat(_apiUrl),
            cancellationToken: cancellationToken);

        if (result == null)
        {
            throw new ArgumentNullException(nameof(result));
        }

        return result;
    }
}
