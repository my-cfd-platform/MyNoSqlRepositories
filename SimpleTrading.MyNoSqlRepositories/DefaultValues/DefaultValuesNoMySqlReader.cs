using System;
using MyNoSqlServer.TcpClient.ReadRepository;
using SimpleTrading.Abstraction.Common.Default;

namespace SimpleTrading.MyNoSqlRepositories.DefaultValues
{
    public class DefaultValuesNoMySqlReader : IDefaultValuesReader
    {
        private readonly IMyNoSqlReadRepository<DefaultValueMyNoSqlTableEntity> _readRepository;

        public DefaultValuesNoMySqlReader(IMyNoSqlReadRepository<DefaultValueMyNoSqlTableEntity> readRepository)
        {
            _readRepository = readRepository ?? throw new ArgumentNullException(nameof(readRepository));
        }

        public IDefaultValue Get(DefaultValueTypes type)
        {
            var partitionKey = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rowKey = DefaultValueMyNoSqlTableEntity.GenerateRowKey(type);

            return _readRepository.Get(partitionKey, rowKey);
        }
    }
}