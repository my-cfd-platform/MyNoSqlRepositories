using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Orderbook;

public class OrderbookMyNoSqlEntity : MyNoSqlDbEntity
{
    public static string GeneratePartitionKey()
    {
        return "*";
    }
        
    public static string GenerateRowKey(string market)
    {
        return market;
    }

    public OrderbookModel Value { get; set; }
}