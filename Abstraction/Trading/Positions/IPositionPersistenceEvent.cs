using MyNoSqlRepositories.Abstraction.Accounts;

namespace MyNoSqlRepositories.Abstraction.Trading.Positions;

public interface IPositionPersistenceEvent
{
    DateTime DateTime { get; set; }
    IEnumerable<ITradeOrder> AccountPositionsSnapshot { get; }
    ITradingAccount Account { get; }
    ITradeOrder PositionUpdate { get; }
    ITradeOrder OpenPosition { get; }
    ITradeOrder ClosePosition { get; }
}