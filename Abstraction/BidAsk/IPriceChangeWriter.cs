namespace MyNoSqlRepositories.Abstraction.BidAsk;

public interface IPriceChangeWriter
{
    Task SaveAsync(IEnumerable<IPriceChange> changes);
}