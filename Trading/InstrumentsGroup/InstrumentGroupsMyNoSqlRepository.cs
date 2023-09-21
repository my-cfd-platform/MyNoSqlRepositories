using MyNoSqlRepositories.Abstraction.Trading.InstrumentsGroup;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Trading.InstrumentsGroup;

public class InstrumentGroupsMyNoSqlRepository : IInstrumentGroupsRepository
{
    private readonly IMyNoSqlServerDataWriter<InstrumentGroupMyNoSqlEntity> _table;

    public InstrumentGroupsMyNoSqlRepository(IMyNoSqlServerDataWriter<InstrumentGroupMyNoSqlEntity> table)
    {
        _table = table;
    }

    public async Task<IEnumerable<IInstrumentGroup>> GetAllAsync()
    {
        var partitionKey = InstrumentGroupMyNoSqlEntity.GeneratePartitionKey();
        return await _table.GetAsync(partitionKey);
    }

    public async Task UpdateAsync(IInstrumentGroup item)
    {
        var entity = InstrumentGroupMyNoSqlEntity.Create(item);
        await _table.InsertOrReplaceAsync(entity);
    }
}