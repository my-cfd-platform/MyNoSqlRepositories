using DotNetCoreDecorators;
using MyNoSqlRepositories.Abstraction.Reports.ActivePositions;
using MyNoSqlRepositories.Abstraction.Trading.Positions;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Reports.ActivePositions;

public class ReportActivePositionMyNoSqlReader : IReportActivePositionsReader
{
    private readonly IMyNoSqlServerDataReader<ReportActivePositionMyNoSqlEntity> _readRepository;

    public ReportActivePositionMyNoSqlReader(IMyNoSqlServerDataReader<ReportActivePositionMyNoSqlEntity> readRepository)
    {
        _readRepository = readRepository ?? throw new ArgumentNullException(nameof(readRepository));
    }


    public IReadOnlyList<ITradeOrder> Get(string accountId)
    {
        var pk = ReportActivePositionMyNoSqlEntity.GeneratePartitionKey();
        var rk = ReportActivePositionMyNoSqlEntity.GenerateRowKey(accountId);

        var entity = _readRepository.Get(pk, rk);

        return entity.ActivePositions.AsReadOnlyList();
    }

    public IReadOnlyList<IActivePositionsSnapshot> Get()
    {
        var pk = ReportActivePositionMyNoSqlEntity.GeneratePartitionKey();

        return _readRepository.Get(pk);
    }
}