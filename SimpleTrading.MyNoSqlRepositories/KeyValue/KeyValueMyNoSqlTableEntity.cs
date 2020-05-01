using MyNoSqlServer.TcpClient;

namespace SimpleTrading.MyNoSqlRepositories.KeyValue
{
    public class KeyValueMyNoSqlTableEntity : MyNoSqlTableEntity
    {
        public static string GeneratePartitionKey(string traderId)
        {
            return traderId;
        }

        public static string GenerateRowKey(string key)
        {
            return key;
        }

        public string Value { get; set; }

        public static KeyValueMyNoSqlTableEntity Create(string traderId, string key, string value)
        {
            return new KeyValueMyNoSqlTableEntity
            {
                PartitionKey = GeneratePartitionKey(traderId),
                RowKey = GenerateRowKey(key),
                Value = value
            };
        }
    }
}