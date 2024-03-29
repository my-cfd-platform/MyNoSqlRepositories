using MyNoSqlRepositories.Abstraction.Trading;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Trading.Profiles;

public class TradingGroupsMyNoSqlReader : ITradingGroupsReader
{
    private readonly IMyNoSqlServerDataReader<TradingGroupMyNoSqlEntity> _reader;

    public TradingGroupsMyNoSqlReader(IMyNoSqlServerDataReader<TradingGroupMyNoSqlEntity> reader)
    {
        _reader = reader;
    }
        
    public IEnumerable<ITradingGroup> GetAll()
    {
        var partitionKey = TradingGroupMyNoSqlEntity.GeneratePartitionKey();
        return _reader.Get(partitionKey);
    }

    public ITradingGroup Get(string id)
    {
        var partitionKey = TradingGroupMyNoSqlEntity.GeneratePartitionKey();
        var rowKey = TradingGroupMyNoSqlEntity.GenerateRowKey(id);
        return _reader.Get(partitionKey, rowKey);
    }
}