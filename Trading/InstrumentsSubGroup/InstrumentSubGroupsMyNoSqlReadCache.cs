using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading.InstrumentsGroup;

namespace MyNoSqlRepositories.Trading.InstrumentsSubGroup;

public class InstrumentSubGroupsMyNoSqlReadCache : IInstrumentSubGroupsCache
{
    private readonly IMyNoSqlServerDataReader<InstrumentSubGroupMyNoSqlEntity> _readRepository;

    public InstrumentSubGroupsMyNoSqlReadCache(IMyNoSqlServerDataReader<InstrumentSubGroupMyNoSqlEntity> readRepository)
    {
        _readRepository = readRepository;
    }
        
    public IEnumerable<IInstrumentSubGroup> GetAll()
    {
        return _readRepository.Get();
    }

    public IInstrumentSubGroup GetById(string groupId, string subGroupId)
    {
        var partitionKey = InstrumentSubGroupMyNoSqlEntity.GeneratePartitionKey(groupId);
        var rowKey = InstrumentSubGroupMyNoSqlEntity.GenerateRowKey(subGroupId);
        return _readRepository.Get(partitionKey, rowKey);
    }
    public IEnumerable<IInstrumentSubGroup> GetByGroupId(string groupId)
    {
        var partitionKey = InstrumentSubGroupMyNoSqlEntity.GeneratePartitionKey(groupId);
        return _readRepository.Get(partitionKey);
    }
}