using MyNoSqlServer.Abstractions;
using MyNoSqlServer.DataWriter;
using SimpleTrading.Abstraction.Markups;

namespace MyNoSqlRepositories.Markups;

public class MarkupProfilesMyNoSqlRepository : IMarkupProfilesRepository
{
    private readonly IMyNoSqlServerDataWriter<MarkupProfileMyNoSqlTableEntity> _table;

    public MarkupProfilesMyNoSqlRepository(MyNoSqlServerDataWriter<MarkupProfileMyNoSqlTableEntity> table)
    {
        _table = table;
    }
        
    public async Task<IEnumerable<IMarkupProfile>> GetAllAsync()
    {
        var pk = MarkupProfileMyNoSqlTableEntity.GeneratePartitionKey();
        return await _table.GetAsync(pk);
    }

    public async Task UpdateAsync(IMarkupProfile markupProfile)
    {
        var entity = MarkupProfileMyNoSqlTableEntity.Create(markupProfile);
        await _table.InsertOrReplaceAsync(entity);
    }

    public async Task<IMarkupProfile> GetById(string profileId)
    {
        var pk = MarkupProfileMyNoSqlTableEntity.GeneratePartitionKey();
        var rk = MarkupProfileMyNoSqlTableEntity.GenerateRowKey(profileId);
        return await _table.GetAsync(pk, rk);
    }
}