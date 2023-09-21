namespace MyNoSqlRepositories.Abstraction.Accounts;

public interface ITradingAccount
{
    string Id { get; }
    string TraderId { get; }
    string Currency { get; }
    double Balance { get; }
    double Bonus { get; }
    string TradingGroup { get; }
    string SwapGroup { get; }
    string MarkupGroup { get; }
    string CommissionGroup { get; }
    string ExecutionGroup { get; }
    string LeverageGroup { get; }
    DateTime CreatedAt { get; }
    DateTime TimeStamp { get; }
    bool TradingDisabled { get; }
}