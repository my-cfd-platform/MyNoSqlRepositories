using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Caches.PendingOrders;
using SimpleTrading.Abstraction.Trading.Positions;
using SimpleTrading.MyNoSqlRepositories.Cache.PendingOrders;

namespace SimpleTrading.MyNoSqlRepositories.Cache.ActiveOrders
{
    public class ActiveOrdersCacheNoSqlReader : IPendingOrdersCacheReader
    {
        private readonly IMyNoSqlServerDataReader<ActiveOrderMyNoSqlEntity> _reader;

        public ActiveOrdersCacheNoSqlReader(IMyNoSqlServerDataReader<ActiveOrderMyNoSqlEntity> reader)
        {
            _reader = reader;
        }


        public IEnumerable<ITradeOrder> GetAllPendingOrders()
        {
            return _reader.Get();
        }

        public IEnumerable<ITradeOrder> GetTraderPendingOrders(string accountId)
        {
            var pk = PendingOrderNoSqlEntity.GeneratePartitionKey(accountId);
            return _reader.Get(pk);
        }

        public ITradeOrder GetPendingOrder(string accountId, long id)
        {
            var pk = PendingOrderNoSqlEntity.GeneratePartitionKey(accountId);
            var rk = PendingOrderNoSqlEntity.GenerateRowKey(id);
            
            return _reader.Get(pk, rk);
        }
    }
}