using MyNoSqlServer.Abstractions;

namespace SimpleTrading.Orderbook.MyNoSql
{
    public class OrderbookMyNoSqlEntity : MyNoSqlDbEntity
    {
        public static string GeneratePartitionKey()
        {
            return "*";
        }
        
        public static string GenerateRowKey(string market)
        {
            return market;
        }

        public OrderbookModel Value { get; set; }
    }
}