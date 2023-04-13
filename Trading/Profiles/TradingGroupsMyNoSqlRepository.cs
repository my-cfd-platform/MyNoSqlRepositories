using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading;

namespace MyNoSqlRepositories.Trading.Profiles;

public class TradingGroupsMyNoSqlRepository : ITradingGroupsRepository
{
    private readonly IMyNoSqlServerDataWriter<TradingGroupMyNoSqlEntity> _table;

    public TradingGroupsMyNoSqlRepository(IMyNoSqlServerDataWriter<TradingGroupMyNoSqlEntity> table)
    {
        _table = table;
    }
        
    public async Task<IEnumerable<ITradingGroup>> GetAllAsync()
    {
        var partitionKey = TradingGroupMyNoSqlEntity.GeneratePartitionKey();
        return await _table.GetAsync(partitionKey);
    }

    public async Task UpdateAsync(ITradingGroup tradingGroup)
    {
        var entity = TradingGroupMyNoSqlEntity.Create(tradingGroup);
        await _table.InsertOrReplaceAsync(entity);
    }
}