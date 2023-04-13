using MyNoSqlRepositories.Orderbook.Abstractions;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Orderbook;

public class OrderbooksMyNoSqlReader : IOrderbooksReader
{
    private readonly IMyNoSqlServerDataReader<OrderbookMyNoSqlEntity> _reader;
        
    public OrderbooksMyNoSqlReader(IMyNoSqlServerDataReader<OrderbookMyNoSqlEntity> reader)
    {
        _reader = reader;
    }
        
    public IEnumerable<OrderbookModel> Get()
    {
        return _reader.Get().Select(x => x.Value);
    }

    public OrderbookModel GetByMarket(string market)
    {
        var pk = OrderbookMyNoSqlEntity.GeneratePartitionKey();
        var rk = OrderbookMyNoSqlEntity.GenerateRowKey(market);

        return _reader.Get(pk, rk)?.Value;
    }
}