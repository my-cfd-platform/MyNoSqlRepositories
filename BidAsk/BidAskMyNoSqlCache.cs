using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.BidAsk;

namespace MyNoSqlRepositories.BidAsk;

public class BidAskMyNoSqlCache: IBidAskCache
{
    private readonly IMyNoSqlServerDataReader<BidAskMyNoSqlTableEntity> _readRepository;

    public BidAskMyNoSqlCache(IMyNoSqlServerDataReader<BidAskMyNoSqlTableEntity> readRepository)
    {
        _readRepository = readRepository;
        _readRepository.SubscribeToUpdateEvents(items =>
        {
            foreach (var sub in _subscribersOnChanges)
                sub(items);
        }, items =>
        {
            foreach (var sub in _subscribersOnDelete)
                sub(items);
        });
    }
        
    public IBidAsk Get(string id)
    {
        var partitionKey = BidAskMyNoSqlTableEntity.GeneratePartitionKey();
        var rowKey = BidAskMyNoSqlTableEntity.GenerateRowKey(id);
        return _readRepository.Get(partitionKey, rowKey);

    }

    public IReadOnlyList<IBidAsk> Get()
    {
        var partitionKey = BidAskMyNoSqlTableEntity.GeneratePartitionKey();
        return _readRepository.Get(partitionKey);

    }
        
        
    private readonly List<Action<IReadOnlyList<IBidAsk>>> _subscribersOnChanges 
        = new List<Action<IReadOnlyList<IBidAsk>>>();

    public void SubscribeOnChanges(Action<IReadOnlyList<IBidAsk>> bidAskChanges)
    {
        _subscribersOnChanges.Add(bidAskChanges);
    }
        
    private readonly List<Action<IReadOnlyList<IBidAsk>>> _subscribersOnDelete 
        = new List<Action<IReadOnlyList<IBidAsk>>>();

    public void SubscribeOnDelete(Action<IReadOnlyList<IBidAsk>> bidAskChanges)
    {
        _subscribersOnChanges.Add(bidAskChanges);
    }
}