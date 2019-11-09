using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlClient;
using SimpleTrading.Core.Instruments;

namespace SimpleTrading.MyNoSqlRepositories.Instruments
{
    public class TradingInstrumentsMyNoSqlRepository : ITradingInstrumentsRepository
    {
        private readonly IMyNoSqlServerClient<TradingInstrumentMyNoSqlEntity> _table;

        public TradingInstrumentsMyNoSqlRepository(IMyNoSqlServerClient<TradingInstrumentMyNoSqlEntity> table)
        {
            _table = table;
        }
        
        public async Task<IEnumerable<ITradingInstrument>> GetAllAsync()
        {
            var partitionKey = TradingInstrumentMyNoSqlEntity.GeneratePartitionKey();
            return await _table.GetAsync(partitionKey);
        }

        public async Task UpdateAsync(ITradingInstrument item)
        {
            var entity = TradingInstrumentMyNoSqlEntity.Create(item);
            await _table.InsertOrReplaceAsync(entity);
        }
    }
}