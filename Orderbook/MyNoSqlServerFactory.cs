using MyNoSqlServer.DataReader;

namespace MyNoSqlRepositories.Orderbook;

public static class OrderbooksMyNoSqlServerFactory
{
    private const string OrderbooksTable = "orderbooks";

    public static OrderbooksMyNoSqlReader CreateOrderbooksMyNoSqlReader(this MyNoSqlTcpClient connection)
    {
        return new OrderbooksMyNoSqlReader(
            new MyNoSqlReadRepository<OrderbookMyNoSqlEntity>(connection, OrderbooksTable));
    }
}