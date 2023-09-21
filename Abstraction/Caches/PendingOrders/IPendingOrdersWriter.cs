using MyNoSqlRepositories.Abstraction.Trading.Positions;

namespace MyNoSqlRepositories.Abstraction.Caches.PendingOrders;

public interface IPendingOrdersWriter
{
    public ValueTask Delete(string accountId, string orderId);
    public ValueTask BulkInsertOrReplace(IEnumerable<ITradeOrder> src);
    public ValueTask UpdateTraderPendingOrder(string accountId, IEnumerable<ITradeOrder> src);
}