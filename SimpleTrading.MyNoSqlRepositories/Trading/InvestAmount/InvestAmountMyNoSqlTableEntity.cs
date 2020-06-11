using MyNoSqlServer.Abstractions;

namespace SimpleTrading.MyNoSqlRepositories.Trading.InvestAmount
{
    public class InvestAmountMyNoSqlTableEntity : MyNoSqlDbEntity, IInvestAmount
    {
        public static string GeneratePartitionKey()
        {
            return "invest-amount";
        }
        
        public static string GenerateRowKey(int value)
        {
            return value.ToString();
        }
        
        public int Value { get; set; }

        public static InvestAmountMyNoSqlTableEntity Create(IInvestAmount src)
        {
            return new InvestAmountMyNoSqlTableEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.Value),
                Value = src.Value
            };
        }
    }
}