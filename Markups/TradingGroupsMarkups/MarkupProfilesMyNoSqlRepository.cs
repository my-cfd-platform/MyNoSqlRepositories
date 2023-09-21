using MyNoSqlRepositories.Abstraction.Markups.TradingGroupMarkupProfiles;
using MyNoSqlServer.Abstractions;
using MyNoSqlServer.DataWriter;

namespace MyNoSqlRepositories.Markups.TradingGroupsMarkups;

public class TradingGroupMarkupProfilesMyNoSqlRepository : ITradingGroupsMarkupProfilesRepository
{
    private readonly IMyNoSqlServerDataWriter<TradingGroupMarkupProfileMyNoSqlTableEntity> _table;

    public TradingGroupMarkupProfilesMyNoSqlRepository(MyNoSqlServerDataWriter<TradingGroupMarkupProfileMyNoSqlTableEntity> table)
    {
        _table = table;
    }
        
    public async Task<IEnumerable<ITradingGroupMarkupProfile>> GetAllAsync()
    {
        var pk = TradingGroupMarkupProfileMyNoSqlTableEntity.GeneratePartitionKey();
        return await _table.GetAsync(pk);
    }

    public async Task UpdateAsync(ITradingGroupMarkupProfile markupProfile)
    {
        var entity = TradingGroupMarkupProfileMyNoSqlTableEntity.Create(markupProfile);
        await _table.InsertOrReplaceAsync(entity);
    }

    public async Task<ITradingGroupMarkupProfile> GetById(string profileId)
    {
        var pk = TradingGroupMarkupProfileMyNoSqlTableEntity.GeneratePartitionKey();
        var rk = TradingGroupMarkupProfileMyNoSqlTableEntity.GenerateRowKey(profileId);
        return await _table.GetAsync(pk, rk);
    }
}