using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading;

namespace SimpleTrading.MyNoSqlRepositories.InstrumentSourcesMaps
{
    public class InstrumentSourcesMapsMyNoSqlRepository
    {
        private readonly IMyNoSqlServerDataWriter<InstrumentSourcesMapsMyNoSqlTableEntity> _table;

        public InstrumentSourcesMapsMyNoSqlRepository(IMyNoSqlServerDataWriter<InstrumentSourcesMapsMyNoSqlTableEntity> table)
        {
            _table = table;
        }

        public async Task<IEnumerable<InstrumentSourcesMapsMyNoSqlTableEntity>> GetAllAsync()
        {
            var pk = InstrumentSourcesMapsMyNoSqlTableEntity.GeneratePartitionKey();
            return await _table.GetAsync(pk);
        }

        public async Task UpdateAsync(IQuoteFeedSource src)
        {
            var entity = InstrumentSourcesMapsMyNoSqlTableEntity.Create(src);
            await _table.InsertOrReplaceAsync(entity);
        }

        public async Task Delete(string instrumentId)
        {
            var pk = InstrumentSourcesMapsMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = InstrumentSourcesMapsMyNoSqlTableEntity.GenerateRowKey(instrumentId);
            await _table.DeleteAsync(pk, rk);
        }
    }
}