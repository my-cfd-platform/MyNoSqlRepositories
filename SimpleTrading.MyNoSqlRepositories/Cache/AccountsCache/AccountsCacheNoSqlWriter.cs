using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Accounts;

namespace SimpleTrading.MyNoSqlRepositories.Cache.AccountsCache
{
    public class AccountsCacheNoSqlWriter
    {
        private readonly IMyNoSqlServerDataWriter<AccountsCacheNoSqlEntity> _table;

        public AccountsCacheNoSqlWriter(IMyNoSqlServerDataWriter<AccountsCacheNoSqlEntity> table)
        {
            _table = table;
        }

        public async Task BulkInsertByDatabaseEntities(IEnumerable<ITradingAccount> databaseEntities)
        {
            var myNoSqlEntities = databaseEntities.Select(AccountsCacheNoSqlEntity.Create);
            await _table.BulkInsertOrReplaceAsync(myNoSqlEntities);
        }

        public async ValueTask<IEnumerable<AccountsCacheNoSqlEntity>> GetTraderAccountsAsync(string traderId)
        {
            return await _table.GetAsync(traderId);
        }

        public async Task<AccountsCacheNoSqlEntity> GetAccount(string traderId, string accountId)
        {
            return await _table.GetAsync(traderId, accountId);
        }
    }
}