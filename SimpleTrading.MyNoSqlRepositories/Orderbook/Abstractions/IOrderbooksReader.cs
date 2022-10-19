using System.Collections.Generic;

namespace SimpleTrading.Orderbook.Abstractions
{
    public interface IOrderbooksReader
    {
        IEnumerable<OrderbookModel> Get();
        OrderbookModel GetByMarket(string market);
    }
}