using System.Collections.Generic;

namespace SimpleTrading.Orderbook.MyNoSql.Abstractions
{
    public interface IOrderbooksReader
    {
        IEnumerable<OrderbookMyNoSqlEntity> Get();
        OrderbookMyNoSqlEntity GetByMarket(string market);
    }
}