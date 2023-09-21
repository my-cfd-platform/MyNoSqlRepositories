namespace MyNoSqlRepositories.Abstraction.Reports.EquitySnapshot;

public interface IEquitySnapshot
{
    DateTime DateTime { get; }

    string AccountId { get; }
        
    string TraderId { get; }
        
    string TradingGroup { get; }

    string Currency { get; }
        
    double Balance { get; }
        
    double FloatingVolume { get; }
        
    double FloatingSwap { get; }

    double GrossFloatingPl { get; }
        
    double NetFloatingPl { get; }
        
    double Equity { get; }

    double InvestedAmountSum { get; }

    double RefillSum { get; }

    double Bonus { get; }

    bool IsInternal { get; }
}