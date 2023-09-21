using MyNoSqlRepositories.Abstraction.Trading.Positions;

namespace MyNoSqlRepositories.Abstraction.Reports.ActivePositions;

public interface IActivePositionsSnapshot
{
    string TraderId { get; }

    string AccountId { get; }
        
    DateTime DateTime { get; }

    IEnumerable<ITradeOrder> ActivePositions { get; }
}