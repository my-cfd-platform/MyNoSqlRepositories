using MyNoSqlServer.TcpClient;
using SimpleTrading.Abstraction.Common.Default;

namespace SimpleTrading.MyNoSqlRepositories.DefaultValues
{
    public class DefaultValueMyNoSqlTableEntity : MyNoSqlTableEntity, IDefaultValue
    {
        public static string GeneratePartitionKey()
        {
            return "dv";
        }

        public static string GenerateRowKey(DefaultValueTypes type)
        {
            return type.ToString();
        }

        public DefaultValueTypes Type { get; set; }
        
        public string Value { get; set; }

        public static DefaultValueMyNoSqlTableEntity Create(IDefaultValue src)
        {
            return new DefaultValueMyNoSqlTableEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.Type),
                Type = src.Type,
                Value = src.Value
            };
        }
    }
}