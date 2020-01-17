using MyNoSqlClient;

namespace SimpleTrading.MyNoSqlRepositories.Trading.InvestAmount
{
    public class InvestAmountMyNoSqlTableEntity : MyNoSqlTableEntity, IInvestAmount
    {
        public static string GeneratePartitionKey()
        {
            return "invest-amount";
        }
        
        public static string GenerateRowKey()
        {
            return "ia";
        }
        
        public int Value { get; set; }

        public static InvestAmountMyNoSqlTableEntity Create(IInvestAmount src)
        {
            return new InvestAmountMyNoSqlTableEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(),
                Value = src.Value
            };
        }
    }
}