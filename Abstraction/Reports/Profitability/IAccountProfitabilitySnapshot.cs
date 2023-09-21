namespace MyNoSqlRepositories.Abstraction.Reports.Profitability;

public interface IAccountProfitabilitySnapshot : ITotalProfitabilitySnapshot
{
    public string AccountId { get; }

    public string TradingGroup { get; }
}