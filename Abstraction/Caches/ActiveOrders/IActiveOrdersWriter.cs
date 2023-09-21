using MyNoSqlRepositories.Abstraction.Trading.Positions;

namespace MyNoSqlRepositories.Abstraction.Caches.ActiveOrders;

public interface IActiveOrdersWriter
{
    public ValueTask BulkInsertOrReplace(IEnumerable<ITradeOrder> src);
    public ValueTask InsertOrReplace(ITradeOrder src);
    public ValueTask UpdateTraderPendingOrder(string accountId, IEnumerable<ITradeOrder> src);
}