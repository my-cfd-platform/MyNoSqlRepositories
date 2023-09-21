using MyNoSqlRepositories.Abstraction.Trading.Swaps;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Swaps;

public class SwapProfileMyNoSqlEntity : MyNoSqlDbEntity, ISwapProfile
{

    public static string GeneratePartitionKey(string id)
    {
        return id;
    }

    public static string GenerateRowKey(string instrumentId)
    {
        return instrumentId;
    }

    public string Id => PartitionKey;
        
    public string InstrumentId => RowKey;
    public double Long { get; set; }
    public double Short { get; set; }

    public static SwapProfileMyNoSqlEntity Create(ISwapProfile src)
    {
        return new SwapProfileMyNoSqlEntity
        {
            PartitionKey = GeneratePartitionKey(src.Id),
            RowKey = GenerateRowKey(src.InstrumentId),
            Long = src.Long,
            Short = src.Short,
        };
    }
}