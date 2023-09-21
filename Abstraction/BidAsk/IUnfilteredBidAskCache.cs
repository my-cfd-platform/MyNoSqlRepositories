namespace MyNoSqlRepositories.Abstraction.BidAsk;

public interface IUnfilteredBidAskCache
{
    IUnfilteredBidAsk Get(string id);
    IReadOnlyList<IBidAsk> Get();
    void SubscribeOnChanges(Action<IReadOnlyList<IUnfilteredBidAsk>> bidAsk);
}