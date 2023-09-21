namespace MyNoSqlRepositories.Abstraction.BidAsk;

public interface IPriceChangeReader
{
    IPriceChange Get(string instrumentId);
    IReadOnlyList<IPriceChange> Get();
    void BindEventSubscribers(Action<IReadOnlyList<IPriceChange>> updateCallback,
        Action<IReadOnlyList<IPriceChange>> deleteCallback);
}