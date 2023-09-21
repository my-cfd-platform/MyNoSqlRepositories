namespace MyNoSqlRepositories.Abstraction.BidAsk;

public interface IBidAsk
{
    string Id { get; }
    DateTime DateTime { get; }
    double Bid { get; set;}
    double Ask { get; set;}
}
    
public class BidAsk : IBidAsk
{
    public string Id { get; set; }
    public DateTime DateTime { get; set; }
    public double Bid { get; set; }
    public double Ask { get; set; }
        
    public static BidAsk Create(string id, double bid, double ask, DateTime dt)
    {
        return new BidAsk
        {
            Ask = ask,
            Bid = bid,
            Id = id,
            DateTime = dt,
        };
    }
        
}