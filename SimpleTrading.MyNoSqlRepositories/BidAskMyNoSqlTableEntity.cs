using System;
using System.Collections.Generic;
using MyNoSqlClient;
using MyNoSqlClient.ReadRepository;
using SimpleTrading.Core.BidsAsks;

namespace SimpleTrading.MyNoSqlRepositories
{
    public class BidAskMyNoSqlTableEntity : MyNoSqlTableEntity, IBidAsk
    {
        
        public static string GeneratePartitionKey()
        {
            return "qp";
        }
        
        public static string GenerateRowKey(string asset)
        {
            return asset;
        }
        
        public DateTime DateTime { get; set; }
        
        public string Id => RowKey;
        
        public double Bid { get; set; }
        
        public double Ask { get; set; }

    }

    
    public class BidAskMyNoSqlCache: IBidAskCache
    {
        private readonly IMyNoSqlReadRepository<BidAskMyNoSqlTableEntity> _readRepository;

        public BidAskMyNoSqlCache(IMyNoSqlReadRepository<BidAskMyNoSqlTableEntity> readRepository)
        {
            _readRepository = readRepository;
            _readRepository.SubscribeToChanges(items =>
            {
                foreach (var sub in _subscribersOnChanges)
                    sub(items);
            });
        }
        
        public IBidAsk Get(string id)
        {
            var partitionKey = BidAskMyNoSqlTableEntity.GeneratePartitionKey();
            var rowKey = BidAskMyNoSqlTableEntity.GenerateRowKey(id);
            return _readRepository.Get(partitionKey, rowKey);

        }

        public IReadOnlyList<IBidAsk> Get()
        {
            var partitionKey = BidAskMyNoSqlTableEntity.GeneratePartitionKey();
            return _readRepository.Get(partitionKey);

        }
        
        
        private readonly List<Action<IReadOnlyList<IBidAsk>>> _subscribersOnChanges 
            = new List<Action<IReadOnlyList<IBidAsk>>>();

        public void SubscribeOnChanges(Action<IReadOnlyList<IBidAsk>> bidAskChanges)
        {
            _subscribersOnChanges.Add(bidAskChanges);
        }
    }
}