using MyNoSqlServer.Abstractions;
using SimpleTrading.QuotesFeedRouter.Abstractions;

namespace MyNoSqlRepositories.InstrumentSourcesMaps;

public class InstrumentSourcesMapsMyNoSqlTableEntity : MyNoSqlDbEntity, IQuoteFeedSource
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

    public static InstrumentSourcesMapsMyNoSqlTableEntity Create(IQuoteFeedSource src)
    {
        return new InstrumentSourcesMapsMyNoSqlTableEntity
        {
            PartitionKey = GeneratePartitionKey(),
            RowKey = GenerateRowKey(src.InstrumentId),
            SourceId = src.SourceId
        };
    }
}