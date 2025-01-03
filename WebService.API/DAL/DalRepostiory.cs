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
SELECT so.[City], SUM(so.[NettoCost]) AS [SumNetto]
FROM dbo.[Shop] s
INNER JOIN dbo.ShopOrder so ON s.[ShopID] = so.[ShopID]
WHERE s.[ShopID] % 2 = 0 AND so.[City] LIKE '%w%'
GROUP BY so.[City]";

        return await sqlConnection.QueryAsync<ShopOrderResponse>(sql);
    }
}
