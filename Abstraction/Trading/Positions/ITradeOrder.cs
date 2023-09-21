using MyNoSqlRepositories.Abstraction.BidAsk;

namespace MyNoSqlRepositories.Abstraction.Trading.Positions;

public interface ITradeOrder
{
    long Id { get; }
    string AccountId { get; }
    string TraderId { get; }
    string Instrument { get; }
    double InvestmentAmount { get; }
    int Leverage { get; }
    DateTime Created { get; }
    double DesiredPrice { get; }
    double OpenPrice { get; }
    IBidAsk OpenBidAsk { get; }
    PositionOperation Operation { get; }
    PositionOrderType PositionOrderType { get; }
    double? TakeProfitInCurrency { get; }
    double? StopLossInCurrency { get; }
    double? TakeProfitRate { get; }
    double? StopLossRate { get; }
    DateTime TimeStamp { get; }
    string ProcessId { get; }
    DateTime OpenDate { get; }
    double Volume { get; }
    IEnumerable<IPositionCommission> Commissions { get; }
    IEnumerable<IPositionSwap> Swaps { get; }
    double ToppingUpPercent { get; }
    double ReservedFundsForToppingUp { get; }
    double Profit { get; }
    DateTime CloseDate { get; }
    ClosePositionReason CloseReason { get; }
    double ClosePrice { get; }
    IBidAsk CloseBidAsk { get; }
    double BurnBonus { get; }
}