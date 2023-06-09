﻿namespace MyNoSqlRepositories.Orderbook.Abstractions;

public interface IOrderbooksReader
{
    IEnumerable<OrderbookModel> Get();
    OrderbookModel GetByMarket(string market);
}