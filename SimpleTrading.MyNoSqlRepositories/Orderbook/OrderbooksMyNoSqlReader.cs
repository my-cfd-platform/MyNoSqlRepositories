using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Orderbook.MyNoSql.Abstractions;

namespace SimpleTrading.Orderbook.MyNoSql
{
    public class OrderbooksMyNoSqlReader : IOrderbooksReader
    {
        private readonly IMyNoSqlServerDataReader<OrderbookMyNoSqlEntity> _reader;
        
        public OrderbooksMyNoSqlReader(IMyNoSqlServerDataReader<OrderbookMyNoSqlEntity> reader)
        {
            _reader = reader;
        }
        
        public IEnumerable<OrderbookMyNoSqlEntity> Get()
        {
            return _reader.Get();
        }

        public OrderbookMyNoSqlEntity GetByMarket(string market)
        {
            var pk = OrderbookMyNoSqlEntity.GeneratePartitionKey();
            var rk = OrderbookMyNoSqlEntity.GenerateRowKey(market);

            return _reader.Get(pk, rk);
        }
    }
}