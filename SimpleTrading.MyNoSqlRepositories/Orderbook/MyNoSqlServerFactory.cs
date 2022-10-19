using MyNoSqlServer.DataReader;

namespace SimpleTrading.Orderbook.MyNoSql
{
    public static class OrderbooksMyNoSqlServerFactory
    {
        private const string OrderbooksTable = "orderbooks";

        public static OrderbooksMyNoSqlReader CreateOrderbooksMyNoSqlReader(this MyNoSqlTcpClient connection)
        {
            return new OrderbooksMyNoSqlReader(
                new MyNoSqlReadRepository<OrderbookMyNoSqlEntity>(connection, OrderbooksTable));
        }
    }
}