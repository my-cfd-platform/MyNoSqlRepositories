using MyNoSqlRepositories.Abstraction.Trading.Positions;

namespace MyNoSqlRepositories.Abstraction.Caches.PendingOrders;

public interface IPendingOrdersCacheReader
{
    public IEnumerable<ITradeOrder> GetAllPendingOrders();
    public IEnumerable<ITradeOrder> GetTraderPendingOrders(string accountId);
    public ITradeOrder GetPendingOrder(string accountId, long id);
    public void BindEventSubscribers(Action<IReadOnlyList<ITradeOrder>> updateCallback,
        Action<IReadOnlyList<ITradeOrder>> deleteCallback);
}