using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlClient;
using SimpleTrading.Abstraction.Trading.InstrumentsGroup;

namespace SimpleTrading.MyNoSqlRepositories.Trading.InstrumentsGroup
{
    public class InstrumentGroupsMyNoSqlRepository : IInstrumentGroupsRepository
    {
        private readonly IMyNoSqlServerClient<InstrumentGroupMyNoSqlEntity> _table;

        public InstrumentGroupsMyNoSqlRepository(IMyNoSqlServerClient<InstrumentGroupMyNoSqlEntity> table)
        {
            _table = table;
        }

        public async Task<IEnumerable<IInstrumentGroup>> GetAllAsync()
        {
            var partitionKey = InstrumentGroupMyNoSqlEntity.GeneratePartitionKey();
            return await _table.GetAsync(partitionKey);
        }

        public async Task UpdateAsync(IInstrumentGroup item)
        {
            var entity = InstrumentGroupMyNoSqlEntity.Create(item);
            await _table.InsertOrReplaceAsync(entity);
        }
    }
}