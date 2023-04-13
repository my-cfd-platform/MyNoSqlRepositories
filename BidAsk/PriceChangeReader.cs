using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.BidAsk;

namespace MyNoSqlRepositories.BidAsk;

public class PriceChangeReader : IPriceChangeReader
{
        
    private readonly IMyNoSqlServerDataReader<PriceChangeMyNoSqlEntity> _readRepository;

    public PriceChangeReader(IMyNoSqlServerDataReader<PriceChangeMyNoSqlEntity> readRepository)
    {
        _readRepository = readRepository;
    }
        
    public IPriceChange Get(string instrumentId)
    {
        var partitionKey = PriceChangeMyNoSqlEntity.GeneratePartitionKey();
        var rowKey = PriceChangeMyNoSqlEntity.GenerateRowKey(instrumentId);

        return _readRepository.Get(partitionKey, rowKey);
    }

    public IReadOnlyList<IPriceChange> Get()
    {
        var partitionKey = PriceChangeMyNoSqlEntity.GeneratePartitionKey();
        return _readRepository.Get(partitionKey);
    }

    public void BindEventSubscribers(Action<IReadOnlyList<IPriceChange>> updateCallback,
        Action<IReadOnlyList<IPriceChange>> deleteCallback) =>
        _readRepository.SubscribeToUpdateEvents(updateCallback, deleteCallback);
}