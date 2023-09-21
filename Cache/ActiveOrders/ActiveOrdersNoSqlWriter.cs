using MyNoSqlRepositories.Abstraction.Caches.ActiveOrders;
using MyNoSqlRepositories.Abstraction.Trading.Positions;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Cache.ActiveOrders;

public class ActiveOrdersCacheNoSqlWriter : IActiveOrdersWriter
{
    private readonly IMyNoSqlServerDataWriter<ActiveOrderMyNoSqlEntity> _table;

    public ActiveOrdersCacheNoSqlWriter(IMyNoSqlServerDataWriter<ActiveOrderMyNoSqlEntity> table)
    {
        _table = table;
    }

    public async ValueTask BulkInsertOrReplace(IEnumerable<ITradeOrder> src)
    {
        await _table.BulkInsertOrReplaceAsync(src.Select(ActiveOrderMyNoSqlEntity.Create).ToArray());
    }

    public async ValueTask InsertOrReplace(ITradeOrder src)
    {
        await _table.InsertOrReplaceAsync(ActiveOrderMyNoSqlEntity.Create(src));
    }

    public async ValueTask UpdateTraderPendingOrder(string accountId, IEnumerable<ITradeOrder> src)
    {
        await _table.CleanAndBulkInsertAsync(accountId, src.Select(ActiveOrderMyNoSqlEntity.Create).ToArray());
    }
}