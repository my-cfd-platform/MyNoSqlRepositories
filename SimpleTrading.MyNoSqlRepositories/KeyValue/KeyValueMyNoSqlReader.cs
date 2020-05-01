using System;
using MyNoSqlServer.TcpClient.ReadRepository;

namespace SimpleTrading.MyNoSqlRepositories.KeyValue
{
    public class KeyValueMyNoSqlReader
    {
        private readonly IMyNoSqlReadRepository<KeyValueMyNoSqlTableEntity> _readRepository;

        public KeyValueMyNoSqlReader(IMyNoSqlReadRepository<KeyValueMyNoSqlTableEntity> repository)
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