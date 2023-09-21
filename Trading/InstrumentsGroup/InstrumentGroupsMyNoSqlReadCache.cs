using MyNoSqlRepositories.Abstraction.Trading.InstrumentsGroup;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Trading.InstrumentsGroup;

public class InstrumentGroupsMyNoSqlReadCache : IInstrumentGroupsCache
{
    private readonly IMyNoSqlServerDataReader<InstrumentGroupMyNoSqlEntity> _readRepository;

    public InstrumentGroupsMyNoSqlReadCache(IMyNoSqlServerDataReader<InstrumentGroupMyNoSqlEntity> readRepository)
    {
        _readRepository = readRepository;
    }
        
    public IEnumerable<IInstrumentGroup> GetAll()
    {
        var partitionKey = InstrumentGroupMyNoSqlEntity.GeneratePartitionKey();
        return _readRepository.Get(partitionKey);
    }

    public IInstrumentGroup Get(string id)
    {
        var partitionKey = InstrumentGroupMyNoSqlEntity.GeneratePartitionKey();
        var rowKey = InstrumentGroupMyNoSqlEntity.GenerateRowKey(id);
        return _readRepository.Get(partitionKey, rowKey);
    }
}