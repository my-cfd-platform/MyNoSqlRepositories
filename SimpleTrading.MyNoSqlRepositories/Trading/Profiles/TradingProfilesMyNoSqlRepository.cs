using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.TcpClient;
using SimpleTrading.Abstraction.Trading.Profiles;

namespace SimpleTrading.MyNoSqlRepositories.Trading.Profiles
{
    public class TradingProfilesMyNoSqlRepository : ITradingProfileRepository
    {
        private readonly IMyNoSqlServerClient<TradingProfileMyNoSqlEntity> _table;

        public TradingProfilesMyNoSqlRepository(IMyNoSqlServerClient<TradingProfileMyNoSqlEntity> table)
        {
            _table = table;
        }
        
        public async Task<IEnumerable<ITradingProfile>> GetAllAsync()
        {
            var partitionKey = TradingProfileMyNoSqlEntity.GeneratePartitionKey();
            return await _table.GetAsync(partitionKey);
        }

        public async Task UpdateAsync(ITradingProfile tradingGroup)
        {
            var entity = TradingProfileMyNoSqlEntity.Create(tradingGroup);
            await _table.InsertOrReplaceAsync(entity);
        }
    }
}