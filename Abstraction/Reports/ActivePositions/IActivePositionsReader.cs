using MyNoSqlRepositories.Abstraction.Trading.Positions;

namespace MyNoSqlRepositories.Abstraction.Reports.ActivePositions;

public interface IReportActivePositionsReader
{
    IReadOnlyList<ITradeOrder> Get(string accountId);

    IReadOnlyList<IActivePositionsSnapshot> Get();
}