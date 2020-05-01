using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.BidAsk;

namespace SimpleTrading.MyNoSqlRepositories.BidAsk
{
    public class PriceChangeReader : IPriceChangeReader
    {
        
        private readonly IMyNoSqlServerDataReader<PriceChangeMyNoSqlEntity> _readRepository;

        public PriceChangeReader(IMyNoSqlServerDataReader<PriceChangeMyNoSqlEntity> readRepository)
        {
            _readRepository = readRepository;
        }
        
        public IPriceChange Get(string instrumentId)
        {
            var partitionKey = PriceChangeMyNoSqlEntity.GeneratePartitionKey();
            var rowKey = PriceChangeMyNoSqlEntity.GenerateRowKey(instrumentId);

            return _readRepository.Get(partitionKey, rowKey);
        }

        public IReadOnlyList<IPriceChange> Get()
        {
            var partitionKey = PriceChangeMyNoSqlEntity.GeneratePartitionKey();
            return _readRepository.Get(partitionKey);
        }
    }
    
}