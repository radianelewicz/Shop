using CustomShop.Web.Models.WebService;
using CustomShop.Web.Services.Constants;

namespace CustomShop.Web.Services;

public interface IWebShopService //najlepiej oddzielny projekt
{
    public Task<IEnumerable<ShopOrderViewModel>> GetAsync(CancellationToken cancellationToken);
}

public class WebShopService : IWebShopService
{
    private readonly string _webServiceApiUrl;

    public WebShopService(IConfiguration configuration)
    {
        _webServiceApiUrl = configuration.GetValue<string>("WebServiceApiUrl")
            ?? throw new ArgumentNullException(nameof(_webServiceApiUrl));
    }

    public async Task<IEnumerable<ShopOrderViewModel>> GetAsync(CancellationToken cancellationToken)
    {
        var httpClient = new HttpClient(); //mozliwe skorzystanie z HttpClientFactory wtedy mozna tam przekazac w ramach definicji juz klienta URL
        var result = await httpClient.GetFromJsonAsync<IEnumerable<ShopOrderViewModel>>(
            string.Concat(_webServiceApiUrl, WebShopServiceUrlSections.ShopOrder),
            cancellationToken: cancellationToken);

        if (result == null)
        {
            throw new ArgumentNullException(nameof(result));
        }

        return result;
    }
}
