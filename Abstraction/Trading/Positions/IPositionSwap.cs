namespace MyNoSqlRepositories.Abstraction.Trading.Positions;

public interface IPositionSwap
{
    DateTime SwapDt { get; }
    DateTime ExecutedDt { get; }
    DateTime? QuoteDt { get; }
    double Long { get; }
    double Short { get; }
    int Amount { get; }
    double Profit { get; }
}