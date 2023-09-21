using MyNoSqlRepositories.Abstraction.Accounts;

namespace MyNoSqlRepositories.Abstraction.Caches.Accounts;

public interface IAccountCacheReader
{
    public IReadOnlyList<ITradingAccount> Get(string accountId);

    public ITradingAccount Get(string accountId, DateTime dateTime);

    public void BindEventSubscribers(Action<IReadOnlyList<ITradingAccount>> updateCallback,
        Action<IReadOnlyList<ITradingAccount>> deleteCallback);
}