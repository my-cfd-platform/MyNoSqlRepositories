using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlClient;
using SimpleTrading.Abstraction.Trading;

namespace SimpleTrading.MyNoSqlRepositories.Trading.Profiles
{
    public class TradingGroupsMyNoSqlRepository : ITradingGroupsRepository
    {
        private readonly IMyNoSqlServerClient<TradingGroupMyNoSqlEntity> _table;

        public TradingGroupsMyNoSqlRepository(IMyNoSqlServerClient<TradingGroupMyNoSqlEntity> table)
        {
            _table = table;
        }
        
        public async Task<IEnumerable<ITradingGroup>> GetAllAsync()
        {
            var partitionKey = TradingGroupMyNoSqlEntity.GeneratePartitionKey();
            return await _table.GetAsync(partitionKey);
        }

        public async Task UpdateAsync(ITradingGroup tradingGroup)
        {
            var entity = TradingGroupMyNoSqlEntity.Create(tradingGroup);
            await _table.InsertOrReplaceAsync(entity);
        }
    }
}