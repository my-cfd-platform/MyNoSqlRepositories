using MyNoSqlRepositories.Abstraction.BidAsk;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.BidAsk;

public class PriceChangeWriteRepository : IPriceChangeWriter
{
    private readonly IMyNoSqlServerDataWriter<PriceChangeMyNoSqlEntity> _table;

    public PriceChangeWriteRepository(IMyNoSqlServerDataWriter<PriceChangeMyNoSqlEntity> table)
    {
        _table = table;
    }
        
    public async Task SaveAsync(IEnumerable<IPriceChange> changes)
    {
        var entities = changes.Select(PriceChangeMyNoSqlEntity.Create);
        await _table.BulkInsertOrReplaceAsync(entities.ToArray());
    }
}