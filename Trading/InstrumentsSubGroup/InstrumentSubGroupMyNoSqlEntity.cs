using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading.InstrumentsGroup;

namespace MyNoSqlRepositories.Trading.InstrumentsSubGroup;

public class InstrumentSubGroupMyNoSqlEntity : MyNoSqlDbEntity, IInstrumentSubGroup
{
    public static string GeneratePartitionKey(string groupId)
    {
        return groupId;
    }

    public static string GenerateRowKey(string id)
    {
        return id;
    }

    public string Id => RowKey;
        
    public string Name { get; set; }

    public string GroupId => PartitionKey;

    public int Weight { get; set; }

    public static InstrumentSubGroupMyNoSqlEntity Create(IInstrumentSubGroup src)
    {
        return new InstrumentSubGroupMyNoSqlEntity
        {
            PartitionKey = GeneratePartitionKey(src.GroupId),
            RowKey = GenerateRowKey(src.Id),
            Name = src.Name,
            Weight = src.Weight
        };
    }
}