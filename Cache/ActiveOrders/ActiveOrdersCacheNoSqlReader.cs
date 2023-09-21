using MyNoSqlRepositories.Abstraction.Caches.ActiveOrders;
using MyNoSqlRepositories.Abstraction.Trading.Positions;
using MyNoSqlRepositories.Cache.PendingOrders;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Cache.ActiveOrders;

public class ActiveOrdersCacheNoSqlReader : IActiveOrdersCacheReader
{
    private readonly IMyNoSqlServerDataReader<ActiveOrderMyNoSqlEntity> _reader;

    public ActiveOrdersCacheNoSqlReader(IMyNoSqlServerDataReader<ActiveOrderMyNoSqlEntity> reader)
    {
        _reader = reader;
    }


    public IEnumerable<ITradeOrder> GetAllPendingOrders()
    {
        return _reader.Get();
    }

    public IEnumerable<ITradeOrder> GetTraderPendingOrders(string accountId)
    {
        var pk = PendingOrderNoSqlEntity.GeneratePartitionKey(accountId);
        return _reader.Get(pk);
    }

    public ITradeOrder GetPendingOrder(string accountId, long id)
    {
        var pk = PendingOrderNoSqlEntity.GeneratePartitionKey(accountId);
        var rk = PendingOrderNoSqlEntity.GenerateRowKey(id);
            
        return _reader.Get(pk, rk);
    }

    public void BindEventSubscribers(Action<IReadOnlyList<ITradeOrder>> updateCallback, Action<IReadOnlyList<ITradeOrder>> deleteCallback)
    {
        _reader.SubscribeToUpdateEvents(updateCallback, deleteCallback);
    }
}