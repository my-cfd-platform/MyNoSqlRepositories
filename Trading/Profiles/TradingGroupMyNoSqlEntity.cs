using MyNoSqlRepositories.Abstraction.Trading;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Trading.Profiles;

public class TradingGroupMyNoSqlEntity : MyNoSqlDbEntity, ITradingGroup
{
    public static string GeneratePartitionKey()
    {
        return "group";
    }
    public static string GenerateRowKey(string profileId)
    {
        return profileId;
    }
        
    public string Id => RowKey;
        
    public string Name { get; set; }
        
    public string TradingProfileId { get; set; }

    public string MarkupProfileId { get; set; }

    public string SwapProfileId { get; set; }

    public bool TradingDisabled { get; set; }

    public static TradingGroupMyNoSqlEntity Create(ITradingGroup src)
    {
        return new TradingGroupMyNoSqlEntity
        {
            PartitionKey = GeneratePartitionKey(),
            RowKey = GenerateRowKey(src.Id),
            Name = src.Name,
            TradingProfileId = src.TradingProfileId,
            MarkupProfileId = src.MarkupProfileId,
            SwapProfileId = src.SwapProfileId,
            TradingDisabled = src.TradingDisabled
        };
    } 
}