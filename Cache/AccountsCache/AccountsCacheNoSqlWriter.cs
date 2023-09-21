using MyNoSqlRepositories.Abstraction.Accounts;
using MyNoSqlRepositories.Abstraction.Caches.Accounts;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Cache.AccountsCache;

public class AccountsCacheNoSqlWriter : IAccountCacheWriter
{
    private readonly IMyNoSqlServerDataWriter<AccountsCacheNoSqlEntity> _table;

    public AccountsCacheNoSqlWriter(IMyNoSqlServerDataWriter<AccountsCacheNoSqlEntity> table)
    {
        _table = table;
    }

    public async Task BulkInsertOrReplace(IEnumerable<ITradingAccount> databaseEntities)
    {
        var myNoSqlEntities = databaseEntities.Select(AccountsCacheNoSqlEntity.Create);
        await _table.BulkInsertOrReplaceAsync(myNoSqlEntities.ToArray());
    }

    public async Task InsertOrReplace(ITradingAccount entity)
    {
        await _table.InsertOrReplaceAsync(AccountsCacheNoSqlEntity.Create(entity));
    }

    public async ValueTask<IEnumerable<ITradingAccount>> GetTraderAccountsAsync()
    {
        return await _table.GetAsync();
    }

    public async ValueTask<IEnumerable<ITradingAccount>> GetTraderAccountsAsync(string traderId)
    {
        return await _table.GetAsync(traderId);
    }

    public async Task<ITradingAccount> GetAccount(string traderId, string accountId)
    {
        return await _table.GetAsync(traderId, accountId);
    }
}