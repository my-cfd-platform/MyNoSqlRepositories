using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading.Profiles;

namespace MyNoSqlRepositories.Trading.Profiles;

public class TradingProfilesMyNoSqlRepository : ITradingProfileRepository
{
    private readonly IMyNoSqlServerDataWriter<TradingProfileMyNoSqlEntity> _table;

    public TradingProfilesMyNoSqlRepository(IMyNoSqlServerDataWriter<TradingProfileMyNoSqlEntity> table)
    {
        _table = table;
    }
        
    public async Task<IEnumerable<ITradingProfile>> GetAllAsync()
    {
        var partitionKey = TradingProfileMyNoSqlEntity.GeneratePartitionKey();
        return await _table.GetAsync(partitionKey);
    }

    public async Task UpdateAsync(ITradingProfile tradingGroup)
    {
        var entity = TradingProfileMyNoSqlEntity.Create(tradingGroup);
        await _table.InsertOrReplaceAsync(entity);
    }
}