using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading.InstrumentsGroup;

namespace SimpleTrading.MyNoSqlRepositories.Trading.InstrumentsSubGroup
{
    public class InstrumentSubGroupsMyNoSqlRepository : IInstrumentSubGroupsRepository
    {
        private readonly IMyNoSqlServerDataWriter<InstrumentSubGroupMyNoSqlEntity> _table;

        public InstrumentSubGroupsMyNoSqlRepository(IMyNoSqlServerDataWriter<InstrumentSubGroupMyNoSqlEntity> table)
        {
            _table = table;
        }

        public async Task<IEnumerable<IInstrumentSubGroup>> GetAllAsync()
        {
            return await _table.GetAsync();
        }

        public async Task<IEnumerable<IInstrumentSubGroup>> GetByGroupIdAsync(string groupId)
        {
            var partitionKey = InstrumentSubGroupMyNoSqlEntity.GeneratePartitionKey(groupId);
            return await _table.GetAsync(partitionKey);
        }

        public async Task UpdateAsync(IInstrumentSubGroup item)
        {
            var entity = InstrumentSubGroupMyNoSqlEntity.Create(item);
            await _table.InsertOrReplaceAsync(entity);
        }

        public async Task DeleteAsync(string groupId, string subGroupId)
        {
            var partitionKey = InstrumentSubGroupMyNoSqlEntity.GeneratePartitionKey(groupId);
            var rowKey = InstrumentSubGroupMyNoSqlEntity.GenerateRowKey(subGroupId);
            await _table.DeleteAsync(partitionKey, rowKey);
        }
    }
}