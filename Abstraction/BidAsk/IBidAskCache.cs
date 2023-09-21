namespace MyNoSqlRepositories.Abstraction.BidAsk;

public interface IBidAskCache
{
    IBidAsk Get(string id);
    IReadOnlyList<IBidAsk> Get();
    void SubscribeOnChanges(Action<IReadOnlyList<IBidAsk>> bidAsk);
}