using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading.Instruments;

namespace MyNoSqlRepositories.Trading.Instruments;

public class TradingInstrumentsMyNoSqlRepository : ITradingInstrumentsRepository
{
    private readonly IMyNoSqlServerDataWriter<TradingInstrumentMyNoSqlEntity> _table;

    public TradingInstrumentsMyNoSqlRepository(IMyNoSqlServerDataWriter<TradingInstrumentMyNoSqlEntity> table)
    {
        _table = table;
    }
        
    public async Task<IEnumerable<ITradingInstrument>> GetAllAsync()
    {
        var partitionKey = TradingInstrumentMyNoSqlEntity.GeneratePartitionKey();
        return await _table.GetAsync(partitionKey);
    }

    public async Task UpdateAsync(ITradingInstrument item)
    {
        var entity = TradingInstrumentMyNoSqlEntity.Create(item);
        await _table.InsertOrReplaceAsync(entity);
    }
}