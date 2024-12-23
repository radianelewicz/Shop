using Microsoft.AspNetCore.Mvc;
using Shops.Service.API.DAL;
using Shops.Service.API.Response;
using System.Net;

namespace Shops.Service.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ShopOrderController : ControllerBase
{
    private readonly ILogger<ShopOrderController> _logger;
    private readonly IDalRepostiory _dalRepostiory;
    public ShopOrderController(
        ILogger<ShopOrderController> logger,
        IDalRepostiory dalRepostiory)
    {
        _logger = logger;
        _dalRepostiory = dalRepostiory;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ShopOrderResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        try
        {
            var result = await _dalRepostiory.GetAsync(cancellationToken);

            if (result.Count() == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }
        catch(Exception ex)
        {
            _logger.LogCritical(ex.Message);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
