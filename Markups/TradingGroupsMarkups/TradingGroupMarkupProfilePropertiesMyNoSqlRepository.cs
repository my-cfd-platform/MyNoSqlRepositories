using MyNoSqlRepositories.Abstraction.Markups.TradingGroupMarkupProfiles;
using MyNoSqlServer.Abstractions;
using MyNoSqlServer.DataWriter;

namespace MyNoSqlRepositories.Markups.TradingGroupsMarkups;

public class TradingGroupMarkupProfilePropertiesMyNoSqlRepository : ITradingGroupMarkupProfilePropertiesRepository
{
    private readonly IMyNoSqlServerDataWriter<TradingGroupMarkupProfilePropertiesMyNoSqlTableEntity> _table;

    public TradingGroupMarkupProfilePropertiesMyNoSqlRepository(MyNoSqlServerDataWriter<TradingGroupMarkupProfilePropertiesMyNoSqlTableEntity> table)
    {
        _table = table;
    }
        
    public async Task<IEnumerable<ITradingGroupMarkupProfileProperties>> GetAllAsync()
    {
        var pk = TradingGroupMarkupProfilePropertiesMyNoSqlTableEntity.GeneratePartitionKey();
        return await _table.GetAsync(pk);
    }

    public async Task UpdateAsync(ITradingGroupMarkupProfileProperties markupProfileProps)
    {
        var entity = TradingGroupMarkupProfilePropertiesMyNoSqlTableEntity.Create(markupProfileProps);
        await _table.InsertOrReplaceAsync(entity);
    }

    public async Task<ITradingGroupMarkupProfileProperties> GetById(string profileId)
    {
        var pk = TradingGroupMarkupProfilePropertiesMyNoSqlTableEntity.GeneratePartitionKey();
        var rk = TradingGroupMarkupProfilePropertiesMyNoSqlTableEntity.GenerateRowKey(profileId);
        return await _table.GetAsync(pk, rk);
    }
}