namespace MyNoSqlRepositories.Abstraction.Reports.Profitability;

public interface ITotalProfitabilitySnapshot
{
    public string Currency { get; }

    public double Deposit { get; }

    public double Withdrawal { get; }

    public double NetDeposit { get; }

    public double GrossClosedPl { get; }

    public double ClosedSwaps { get; }

    public double NetClosedPl { get; }

    public double VolumeClosed { get; }

    public double Balance { get; }

    public double FloatingSwap { get; }

    public double FloatingVolume { get; }

    public double GrossFloatingPl { get; }

    public double NetFloatingPl { get; }

    public double Equity { get; }

    public double NetTradingResult { get; }

    public double NetTradingResultPercent { get; }

    public DateTime DateTime { get; }

    public bool IsInternal { get; }
}