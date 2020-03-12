using MyNoSqlClient;
using SimpleTrading.Abstraction.Trading;

namespace SimpleTrading.MyNoSqlRepositories.InstrumentSourcesMaps
{
    public class InstrumentSourcesMapsMyNoSqlTableEntity : MyNoSqlTableEntity, IQuoteFeedSource
    {
        public static string GeneratePartitionKey()
        {
            return "qg";
        }
        
        public static string GenerateRowKey(string id)
        {
            return id;
        }

        public string InstrumentId => RowKey;
        
        public string SourceId { get; set; }
    }
}