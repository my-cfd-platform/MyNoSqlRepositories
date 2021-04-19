using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;

namespace SimpleTrading.MyNoSqlRepositories.Engine
{
    public class EnginePersistenceQueueItemMyNoSqlRepository
    {
        private readonly IMyNoSqlServerDataWriter<EnginePersistenceQueueItemMyNoSqlModel> _table;

        public EnginePersistenceQueueItemMyNoSqlRepository(IMyNoSqlServerDataWriter<EnginePersistenceQueueItemMyNoSqlModel> table)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
        }
        
        public async Task<EnginePersistenceQueueItemMyNoSqlModel> InsertOrReplace(string accountId, DateTime dateTime, object data)
        {
            var entity = EnginePersistenceQueueItemMyNoSqlModel.Create(accountId,dateTime,data);
            await _table.InsertOrReplaceAsync(entity);

            return entity;
        }
        
        public async Task Delete(string accountId, DateTime dateTime)
        {
            var pk = EnginePersistenceQueueItemMyNoSqlModel.GeneratePartitionKey(accountId);
            var rk = EnginePersistenceQueueItemMyNoSqlModel.GenerateRowKey(dateTime);
            
            await _table.DeleteAsync(pk, rk);
        }
        
        public async Task BulkInsertOrReplaceAsync(IEnumerable<EnginePersistenceQueueItemMyNoSqlModel> dataToInsert)
        {
            await _table.BulkInsertOrReplaceAsync(dataToInsert);
        }
    }
}