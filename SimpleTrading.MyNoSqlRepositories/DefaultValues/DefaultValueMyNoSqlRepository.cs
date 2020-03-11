using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlClient;
using SimpleTrading.Abstraction.Common.Default;

namespace SimpleTrading.MyNoSqlRepositories.DefaultValues
{
    public class DefaultValuesMyNoSqlRepository : IDefaultValuesRepository
    {
        private readonly IMyNoSqlServerClient<DefaultValueMyNoSqlTableEntity> _table;

        public DefaultValuesMyNoSqlRepository(IMyNoSqlServerClient<DefaultValueMyNoSqlTableEntity> table)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
        }
        
        public async Task<IEnumerable<IDefaultValue>> GetAllAsync()
        {
            var partitionKey = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            return await _table.GetAsync(partitionKey);
        }

        public async Task UpdateAsync(IDefaultValue defaultValue)
        {
            var entity = DefaultValueMyNoSqlTableEntity.Create(defaultValue);
            await _table.InsertAsync(entity);
        }

        public async Task<IDefaultValue> GetByTypeAsync(DefaultValueTypes type)
        {
            var partitionKey = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rowKey = DefaultValueMyNoSqlTableEntity.GenerateRowKey(type);

            return await _table.GetAsync(partitionKey, rowKey);
        }
    }
}