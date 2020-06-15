using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.BidAsk;

namespace SimpleTrading.MyNoSqlRepositories.BidAsk
{
    public class PriceChangeMyNoSqlEntity : MyNoSqlDbEntity, IPriceChange
    {
        public static string GeneratePartitionKey()
        {
            return "ch";
        }

        public static string GenerateRowKey(string id)
        {
            return id;
        }
        
        public string Id => RowKey;
        public double Chng { get; set; }
        double IPriceChange.Change => Chng;


        public static PriceChangeMyNoSqlEntity Create(IPriceChange src)
        {
            return new PriceChangeMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.Id),
                Chng = src.Change
            };
        }
    }
    
    
}