using MyNoSqlRepositories.Abstraction.Accounts;
using MyNoSqlRepositories.Abstraction.Caches.Accounts;
using MyNoSqlRepositories.Engine;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Cache.AccountsCache;

public class AccountCacheNoSqlReader : IAccountCacheReader
{
    private readonly IMyNoSqlServerDataReader<AccountsCacheNoSqlEntity> _reader;

    public AccountCacheNoSqlReader(IMyNoSqlServerDataReader<AccountsCacheNoSqlEntity> reader)
    {
        _reader = reader;
    }

    public IReadOnlyList<ITradingAccount> Get(string accountId)
    {
        var pk = EnginePersistenceQueueItemMyNoSqlModel.GeneratePartitionKey(accountId);

        return _reader.Get(pk);
    }

    public ITradingAccount Get(string accountId, DateTime dateTime)
    {
        var pk = EnginePersistenceQueueItemMyNoSqlModel.GeneratePartitionKey(accountId);
        var rk = EnginePersistenceQueueItemMyNoSqlModel.GenerateRowKey(dateTime);

        return _reader.Get(pk, rk);
    }

    public void BindEventSubscribers(Action<IReadOnlyList<ITradingAccount>> updateCallback,
        Action<IReadOnlyList<ITradingAccount>> deleteCallback)
    {
        _reader.SubscribeToUpdateEvents(updateCallback, deleteCallback);
    }
}