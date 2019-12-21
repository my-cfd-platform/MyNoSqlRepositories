using System.Collections.Generic;
using MyNoSqlClient.ReadRepository;
using SimpleTrading.Abstraction.Trading.Profiles;

namespace SimpleTrading.MyNoSqlRepositories.Trading.Profiles
{
    public class TradingProfileMyNoSqlReader : ITradingProfilesReader
    {
        private readonly IMyNoSqlReadRepository<TradingProfileMyNoSqlEntity> _reader;

        public TradingProfileMyNoSqlReader(IMyNoSqlReadRepository<TradingProfileMyNoSqlEntity> reader)
        {
            _reader = reader;
        }
        
        public IEnumerable<ITradingProfile> GetAll()
        {
            var partitionKey = TradingProfileMyNoSqlEntity.GeneratePartitionKey();
            return _reader.Get(partitionKey);
        }

        public ITradingProfile Get(string id)
        {
            var partitionKey = TradingProfileMyNoSqlEntity.GeneratePartitionKey();
            var rowKey = TradingProfileMyNoSqlEntity.GenerateRowKey(id);
            return _reader.Get(partitionKey, rowKey);
        }
    }
}