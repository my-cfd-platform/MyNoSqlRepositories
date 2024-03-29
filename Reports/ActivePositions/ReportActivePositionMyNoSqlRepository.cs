using MyNoSqlRepositories.Abstraction.Reports.ActivePositions;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Reports.ActivePositions;

public class ReportActivePositionMyNoSqlRepository : IReportActivePositionsRepository
{
    private readonly IMyNoSqlServerDataWriter<ReportActivePositionMyNoSqlEntity> _table;

    public ReportActivePositionMyNoSqlRepository(IMyNoSqlServerDataWriter<ReportActivePositionMyNoSqlEntity> table)
    {
        _table = table ?? throw new ArgumentNullException(nameof(table));
    }

    public async Task<IEnumerable<IActivePositionsSnapshot>> GetAsync()
    {
        var pk = ReportActivePositionMyNoSqlEntity.GeneratePartitionKey();

        return await _table.GetAsync(pk);
    }

    public async Task<IEnumerable<IActivePositionsSnapshot>> GetAsync(string accountId)
    {
        var pk = ReportActivePositionMyNoSqlEntity.GeneratePartitionKey();

        return await _table.GetAsync(pk);        
    }

    public async Task SaveAsync(IActivePositionsSnapshot snapshot)
    {
        var entity = ReportActivePositionMyNoSqlEntity.Create(snapshot);

        await _table.InsertOrReplaceAsync(entity);
    }
}