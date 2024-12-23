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

    public Task<IEnumerable<ShopOrderResponse>> GetAsync(CancellationToken cancellationToken)
    {
        using var sqlConnection = new SqlConnection(_connectionString);
        const string sql = @"
SELECT so.City, SUM(so.Netto) AS [SumNetto]
FROM dbo.Shop s
FROM dbo.ShopOrder so
WHERE s.ShopID % 2 = 0 AND so.City LIKE '%w%'
GROUP BY so.City";

        return sqlConnection.QueryAsync<ShopOrderResponse>(
            new CommandDefinition(
                sql,
                sqlConnection.BeginTransaction(),
                cancellationToken: cancellationToken));
    }
}
