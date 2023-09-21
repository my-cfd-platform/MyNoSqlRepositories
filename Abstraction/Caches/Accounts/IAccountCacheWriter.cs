using MyNoSqlRepositories.Abstraction.Accounts;

namespace MyNoSqlRepositories.Abstraction.Caches.Accounts;

public interface IAccountCacheWriter
{
    Task BulkInsertOrReplace(IEnumerable<ITradingAccount> databaseEntities);

    Task InsertOrReplace(ITradingAccount entity);

    ValueTask<IEnumerable<ITradingAccount>> GetTraderAccountsAsync();
    ValueTask<IEnumerable<ITradingAccount>> GetTraderAccountsAsync(string traderId);

    Task<ITradingAccount> GetAccount(string traderId, string accountId);
}