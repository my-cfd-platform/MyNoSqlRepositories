namespace MyNoSqlRepositories.Abstraction.BidAsk;

public interface IUnfilteredBidAsk
{
    string Id { get; }
    DateTime DateTime { get; }
    double Bid { get; }
    double Ask { get; }
    string LiquidityProvider { get; }
}

public class UnfilteredBidAsk : IUnfilteredBidAsk
{
    public string Id { get; set; }
    public DateTime DateTime { get; set; }
    public double Bid { get; set; }
    public double Ask { get; set; }
    public string LiquidityProvider { get; set; }

    public static UnfilteredBidAsk Create(string id, double bid, double ask, DateTime dt, string lp)
    {
        return new UnfilteredBidAsk
        {
            Ask = ask,
            Bid = bid,
            Id = id,
            DateTime = dt,
            LiquidityProvider = lp,
        };
    }
}