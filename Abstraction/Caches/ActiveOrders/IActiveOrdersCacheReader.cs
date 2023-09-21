using MyNoSqlRepositories.Abstraction.Trading.Positions;

namespace MyNoSqlRepositories.Abstraction.Caches.ActiveOrders;

public interface IActiveOrdersCacheReader
{
    public IEnumerable<ITradeOrder> GetAllPendingOrders();
    public IEnumerable<ITradeOrder> GetTraderPendingOrders(string accountId);
    public ITradeOrder GetPendingOrder(string accountId, long id);
    public void BindEventSubscribers(Action<IReadOnlyList<ITradeOrder>> updateCallback,
        Action<IReadOnlyList<ITradeOrder>> deleteCallback);
}