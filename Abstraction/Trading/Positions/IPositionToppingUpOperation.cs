using MyNoSqlRepositories.Abstraction.BidAsk;

namespace MyNoSqlRepositories.Abstraction.Trading.Positions;

public interface IPositionToppingUpOperation
{
    string Id { get; }
    string TraderId { get; }
    string AccountId { get; set; }
    long PositionId { get; set; }
    double Amount { get; }
    double TriggeredProfit { get; }
    IBidAsk TriggeredBidAsk { get; }
    DateTime DateTime { get; }
}