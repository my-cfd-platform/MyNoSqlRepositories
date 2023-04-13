using SimpleTrading.Abstraction.Trading.Positions;

namespace MyNoSqlRepositories.Reports.ActivePositions.TradeOrder;

public class PositionSwapEntity : IPositionSwap
{
    public DateTime SwapDt { get; set; }
    public DateTime ExecutedDt { get; set; }
    public DateTime? QuoteDt { get; set; }
    public double Long { get; set; }
    public double Short { get; set; }
    public int Amount { get; set; }
    public double Profit { get; set; }


    public static PositionSwapEntity Create(IPositionSwap src)
    {
        return new PositionSwapEntity
        {
            SwapDt = src.SwapDt,
            ExecutedDt = src.ExecutedDt,
            QuoteDt = src.QuoteDt,
            Long = src.Long,
            Short = src.Short,
            Amount = src.Amount,
            Profit = src.Profit
        };
    }
}