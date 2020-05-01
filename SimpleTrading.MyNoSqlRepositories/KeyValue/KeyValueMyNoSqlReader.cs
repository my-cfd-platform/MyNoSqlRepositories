using System;
using MyNoSqlServer.Abstractions;

namespace SimpleTrading.MyNoSqlRepositories.KeyValue
{
    public class KeyValueMyNoSqlReader
    {
        private readonly IMyNoSqlServerDataReader<KeyValueMyNoSqlTableEntity> _readRepository;

        public KeyValueMyNoSqlReader(IMyNoSqlServerDataReader<KeyValueMyNoSqlTableEntity> repository)
        {
            _readRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public KeyValueMyNoSqlTableEntity Get(string traderId, string key)
        {
            var partitionKey = KeyValueMyNoSqlTableEntity.GeneratePartitionKey(traderId);
            var rowKey = KeyValueMyNoSqlTableEntity.GenerateRowKey(key);

            return _readRepository.Get(partitionKey, rowKey);
        }
    }
}