namespace MyNoSqlRepositories.Abstraction.Reports.EquitySnapshot;

public interface ITotalEquitySnapshot
{
    DateTime DateTime { get; }

    double Balance { get; }
        
    double FloatingVolume { get; }
        
    double FloatingSwap { get; }

    double GrossFloatingPl { get; }
        
    double NetFloatingPl { get; }
        
    double Equity { get; }

    double InvestedAmount { get; }

    double RefillSum { get; }

    double Bonus { get; }

    bool IsInternal { get; }
}