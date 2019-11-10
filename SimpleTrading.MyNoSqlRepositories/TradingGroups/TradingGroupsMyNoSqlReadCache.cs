using System.Collections.Generic;
using MyNoSqlClient.ReadRepository;
using SimpleTrading.Core.TradingGroups;

namespace SimpleTrading.MyNoSqlRepositories.TradingGroups
{
    public class TradingGroupsMyNoSqlReader : ITradingGroupsReader
    {
        private readonly IMyNoSqlReadRepository<TradingGroupMyNoSqlEntity> _reader;

        public TradingGroupsMyNoSqlReader(IMyNoSqlReadRepository<TradingGroupMyNoSqlEntity> reader)
        {
            _reader = reader;
        }
        
        public IEnumerable<ITradingGroup> GetAll()
        {
            var partitionKey = TradingGroupMyNoSqlEntity.GeneratePartitionKey();
            return _reader.Get(partitionKey);
        }

        public ITradingGroup Get(string id)
        {
            var partitionKey = TradingGroupMyNoSqlEntity.GeneratePartitionKey();
            var rowKey = TradingGroupMyNoSqlEntity.GenerateRowKey(id);
            return _reader.Get(partitionKey, rowKey);
        }
    }
}