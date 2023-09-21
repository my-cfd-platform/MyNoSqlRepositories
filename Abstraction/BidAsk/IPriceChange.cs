namespace MyNoSqlRepositories.Abstraction.BidAsk;

public interface IPriceChange
{
    string Id { get; }
    double Change { get; }
}