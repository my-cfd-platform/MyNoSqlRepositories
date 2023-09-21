using MyNoSqlRepositories.Abstraction.Trading.InstrumentsGroup;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Trading.InstrumentsGroup;

public class InstrumentGroupMyNoSqlEntity : MyNoSqlDbEntity, IInstrumentGroup
{
    public static string GeneratePartitionKey()
    {
        return "ig";
    }

    public static string GenerateRowKey(string id)
    {
        return id;
    }

    public string Id => RowKey;
        
    public string Name { get; set; }
    public int Weight { get; set; }

    public static InstrumentGroupMyNoSqlEntity Create(IInstrumentGroup src)
    {
        return new InstrumentGroupMyNoSqlEntity
        {
            PartitionKey = GeneratePartitionKey(),
            RowKey = GenerateRowKey(src.Id),
            Name = src.Name,
            Weight = src.Weight
        };
    }
}