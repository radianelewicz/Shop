using Dapper;
using Shops.Service.API.Response;
using System.Data.SqlClient;

namespace Shops.Service.API.DAL;

public interface IDalRepostiory
{
    public Task<IEnumerable<ShopOrderResponse>> GetAsync(CancellationToken cancellationToken);
}

public class DalRepostiory : IDalRepostiory
{
    private readonly string _connectionString;
    public DalRepostiory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ShopsContext")!;
    }

    public async Task<IEnumerable<ShopOrderResponse>> GetAsync(CancellationToken cancellationToken)
    {
        using var sqlConnection = new SqlConnection(_connectionString);
        const string sql = @"
WITH cte AS (
	SELECT o.[ShopOrderId], ca.[City], SUM(o.[NettoCost]) AS [SumNetto]
	FROM dbo.[Order] o
	INNER JOIN dbo.[ClientAddress] ca ON ca.[ShopOrderID] = o.[ShopOrderID]
	GROUP BY o.[ShopOrderId], ca.[City]
)
SELECT c.[City], SUM(c.[SumNetto]) AS [SumNetto]
FROM dbo.[Shop] s
INNER JOIN dbo.[ShopOrder] so ON s.[ShopID] = so.[ShopID]
INNER JOIN cte c ON c.[ShopOrderID] = so.[ShopOrderID]
WHERE s.[ShopID] % 2 = 0 AND c.[City] LIKE '%w%'
GROUP BY c.[City]";

        return await sqlConnection.QueryAsync<ShopOrderResponse>(sql);
    }
}
