using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.TcpClient;
using SimpleTrading.Abstraction.Trading;

namespace SimpleTrading.MyNoSqlRepositories.InstrumentSourcesMaps
{
    public class InstrumentSourcesMapsMyNoSqlRepository
    {
        private readonly IMyNoSqlServerClient<InstrumentSourcesMapsMyNoSqlTableEntity> _table;

        public InstrumentSourcesMapsMyNoSqlRepository(IMyNoSqlServerClient<InstrumentSourcesMapsMyNoSqlTableEntity> table)
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