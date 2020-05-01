using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.TcpClient;

namespace SimpleTrading.MyNoSqlRepositories.KeyValue
{
    public class KeyValueMyNoSqlRepository
    {
        private readonly IMyNoSqlServerClient<KeyValueMyNoSqlTableEntity> _table;

        public KeyValueMyNoSqlRepository(IMyNoSqlServerClient<KeyValueMyNoSqlTableEntity> repository)
        {
            _table = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<KeyValueMyNoSqlTableEntity>> GetAllAsync()
        {
            return await _table.GetAsync();
        }

        public async Task SaveAsync(string traderId, string key, string value)
        {
            var entity = KeyValueMyNoSqlTableEntity.Create(traderId, key, value);
            await _table.InsertOrReplaceAsync(entity);
        }
        
        public async Task<string> GetAsync(string traderId, string key)
        {
            var partitionKey = KeyValueMyNoSqlTableEntity.GeneratePartitionKey(traderId);
            var rowKey = KeyValueMyNoSqlTableEntity.GenerateRowKey(key);

            var entity = await _table.GetAsync(partitionKey, rowKey);

            return entity?.Value;
        }
    }
}